using Jusfr.Persistent.Reflection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    public class MockRepository<TEntry> : RepositoryBase<TEntry, Int32> {
        public const String IdField = "Id";
        private static Int32 _id = 0;
        private static readonly ConcurrentBag<TEntry> _all = new ConcurrentBag<TEntry>();

        public MockRepository()
            : base(null) {
        }

        public override void Create(TEntry entity) {
            System.Threading.Interlocked.Increment(ref _id);
            PropertyAccessor.Set(entity, IdField, _id);
            _all.Add(entity);
        }

        public override void Delete(TEntry entity) {
            _all.TryTake(out entity);
        }

        public override void Delete(params Expression<Func<TEntry, bool>>[] predicates) {
            IQueryable<TEntry> left = All;
            foreach (var predicate in predicates) {
                left = left.Where(predicate);
            }

            var entities = left.ToArray();
            TEntry entity;
            for (int i = 0; i < entities.Length; i++) {
                entity = entities[i];
                _all.TryPeek(out entity);
            }
        }

        public override void Delete(IList<TEntry> entities) {
            TEntry entity;
            for (int i = 0; i < entities.Count; i++) {
                entity = entities[i];
                _all.TryPeek(out entity);
            }
        }

        public override void Update(TEntry entity) {

        }

        public override void Update(IList<TEntry> entities) {

        }

        public override bool Exist(params Expression<Func<TEntry, bool>>[] predicates) {
            IQueryable<TEntry> left = All;
            foreach (var predicate in predicates) {
                left = left.Where(predicate);
            }
            return left.Any();
        }

        public override TEntry Retrive(int key) {
            foreach (var entity in _all) {
                Int32 id = (Int32)PropertyAccessor.Get(entity, IdField);
                if (id == key) {
                    return entity;
                }
            }
            return default(TEntry);
        }

        public override IList<TEntry> Retrive(String field, IList<int> keys) {
            var left = new List<TEntry>();
            foreach (var entity in _all) {
                Int32 id = (Int32)PropertyAccessor.Get(entity, field);
                if (keys.Contains(id)) {
                    left.Add(entity);
                }
            }
            return left;
        }

        public override IQueryable<TEntry> All {
            get { return _all.AsQueryable(); }
        }
    }
}

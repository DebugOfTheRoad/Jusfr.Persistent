using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    public class FackRepository<TEntry> : Repository<TEntry> {
        private Int32 _id = 0;
        private readonly List<TEntry> _all = new List<TEntry>();

        public String PrimaryKey { get; set; }

        public FackRepository()
            : base(null) {
        }

        public override void Create(TEntry entry) {
            System.Threading.Interlocked.Increment(ref _id);
            _all.Add(entry);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void Delete(TEntry entry) {
            _all.Remove(entry);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void Delete(IEnumerable<TEntry> entries) {
            foreach (var entry in entries) {
                _all.Remove(entry);
            }
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void Update(TEntry entry) {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public override void Update(IEnumerable<TEntry> entries) {
        }

        public override TEntry Retrive<TKey>(TKey key) {
            foreach (var entry in _all) {
                var key2 = (TKey)PropertyAccessor.Get(entry, PrimaryKey);
                if (key.Equals(key2)) {
                    return entry;
                }
            }
            return default(TEntry);
        }

        public override IEnumerable<TEntry> Retrive<TKey>(String field, IList<TKey> keys) {
            var list = new List<TEntry>();
            foreach (var entry in _all) {
                var key = (TKey)PropertyAccessor.Get(entry, PrimaryKey);
                if (keys.Contains(key)) {
                    list.Add(entry);
                }
            }
            return list;
        }

        public override IQueryable<TEntry> All {
            get { return _all.AsQueryable(); }
        }
    }
}

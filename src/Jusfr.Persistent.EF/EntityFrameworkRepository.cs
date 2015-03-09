using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent.EF {
    public class EntityFrameworkRepository<TEntry, TKey> : RepositoryBase<TEntry, TKey>
        where TEntry : class {
        public EntityFrameworkRepositoryContext EFContext { get; private set; }

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context) {
            if (!(context is EntityFrameworkRepositoryContext)) {
                throw new ArgumentOutOfRangeException("context",
                   "Expect EntityFrameworkRepositoryContext but provided " + context.GetType().FullName);
            }
            EFContext = (EntityFrameworkRepositoryContext)context;
        }

        public override void Create(TEntry entity) {
            EFContext.DBContext.Set<TEntry>().Attach(entity);
            EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Added;
            EFContext.DBContext.SaveChanges();
        }

        public override void Delete(TEntry entity) {
            EFContext.DBContext.Set<TEntry>().Attach(entity);
            EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Deleted;
            EFContext.DBContext.SaveChanges();
        }

        public override void Delete(IList<TEntry> entities) {
            foreach (var entity in entities) {
                EFContext.DBContext.Set<TEntry>().Attach(entity);
                EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Deleted;
            }
            EFContext.DBContext.SaveChanges();
        }

        public override void Delete(params Expression<Func<TEntry, bool>>[] predicates) {
            IQueryable<TEntry> query = All;
            foreach (var predicate in predicates) {
                query = query.Where(predicate);
            }
            var entities = query.ToList();
            foreach (var entity in entities) {
                EFContext.DBContext.Set<TEntry>().Attach(entity);
                EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Deleted;
            }
            EFContext.DBContext.SaveChanges();
        }

        public override void Update(TEntry entity) {
            EFContext.DBContext.Set<TEntry>().Attach(entity);
            EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Modified;
            EFContext.DBContext.SaveChanges();
        }

        public override void Update(IList<TEntry> entities) {
            foreach (var entity in entities) {
                EFContext.DBContext.Set<TEntry>().Attach(entity);
                EFContext.DBContext.Entry<TEntry>(entity).State = EntityState.Modified;
            }
            EFContext.DBContext.SaveChanges();
        }

        public override bool Exist(params Expression<Func<TEntry, bool>>[] predicates) {
            IQueryable<TEntry> query = All;
            foreach (var predicate in predicates) {
                query = query.Where(predicate);
            }
            return query.Count() > 0;
        }

        public override TEntry Retrive(TKey key) {
            return EFContext.DBContext.Set<TEntry>().Find(key);
        }

        public override IList<TEntry> Retrive(String field, IList<TKey> keys) {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntry> All {
            get { return EFContext.DBContext.Set<TEntry>(); }
        }
    }
}

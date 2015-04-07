using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent.EF {
    public class EntityFrameworkRepository<TEntry> : Repository<TEntry>
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

        public override void Create(TEntry entry) {
            EFContext.DBContext.Set<TEntry>().Attach(entry);
            EFContext.DBContext.Entry<TEntry>(entry).State = EntityState.Added;
            EFContext.DBContext.SaveChanges();
        }

        public override void Delete(TEntry entry) {
            EFContext.DBContext.Set<TEntry>().Attach(entry);
            EFContext.DBContext.Entry<TEntry>(entry).State = EntityState.Deleted;
            EFContext.DBContext.SaveChanges();
        }

        public override void Delete(IEnumerable<TEntry> entries) {
            foreach (var entry in entries) {
                EFContext.DBContext.Set<TEntry>().Attach(entry);
                EFContext.DBContext.Entry<TEntry>(entry).State = EntityState.Deleted;
            }
            EFContext.DBContext.SaveChanges();
        }
        
        public override void Update(TEntry entry) {
            EFContext.DBContext.Set<TEntry>().Attach(entry);
            EFContext.DBContext.Entry<TEntry>(entry).State = EntityState.Modified;
            EFContext.DBContext.SaveChanges();
        }

        public override void Update(IEnumerable<TEntry> entries) {
            foreach (var entry in entries) {
                EFContext.DBContext.Set<TEntry>().Attach(entry);
                EFContext.DBContext.Entry<TEntry>(entry).State = EntityState.Modified;
            }
            EFContext.DBContext.SaveChanges();
        }
        
        public override TEntry Retrive<TKey>(TKey key) {
            return EFContext.DBContext.Set<TEntry>().Find(key);
        }

        public override IEnumerable<TEntry> Retrive<TKey>(string field, IList<TKey> keys) {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntry> All {
            get { return EFContext.DBContext.Set<TEntry>(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    public abstract class RepositoryBase<TEntry, TKey> : IRepository<TEntry, TKey> {
        public RepositoryBase(IRepositoryContext context) {
            Context = context;
        }

        public IRepositoryContext Context { get; private set; }
        public abstract void Create(TEntry entity);
        public abstract void Delete(TEntry entity);
        public abstract void Delete(params Expression<Func<TEntry, Boolean>>[] predicates);
        public abstract void Delete(IList<TEntry> entities);
        public abstract void Update(TEntry entity);
        public abstract void Update(IList<TEntry> entities);
        public abstract Boolean Exist(params Expression<Func<TEntry, Boolean>>[] predicates);
        public abstract TEntry Retrive(TKey key);
        public abstract IList<TEntry> Retrive(String field, IList<TKey> keys);
        public abstract IQueryable<TEntry> All { get; }
    }
}

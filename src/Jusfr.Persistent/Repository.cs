using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jusfr.Persistent {
    public interface IRepository<TEntry, TKey> {
        void Create(TEntry entity);
        void Delete(TEntry entity);
        void Delete(IList<TEntry> entities);
        void Delete(params Expression<Func<TEntry, Boolean>>[] predicates);
        void Update(TEntry entity);
        void Update(IList<TEntry> entities);
        Boolean Exist(params Expression<Func<TEntry, Boolean>>[] predicates);
        TEntry Retrive(TKey key);
        IList<TEntry> Retrive(String filed, IList<TKey> keys);
        IQueryable<TEntry> All { get; }
        IRepositoryContext Context { get; }
    }
}


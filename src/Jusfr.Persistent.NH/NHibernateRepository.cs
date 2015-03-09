using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent.NH {
    public class NHibernateRepository<TEntry, TKey> : RepositoryBase<TEntry, TKey> where TEntry : class {
        public NHibernateRepositoryContext NHContext { get; private set; }

        public NHibernateRepository(IRepositoryContext context)
            : base(context) {
            if (!(context is NHibernateRepositoryContext)) {
                throw new ArgumentOutOfRangeException("context",
                    "Expect NHibernateRepositoryContext but provided " + context.GetType().FullName);
            }
            NHContext = (NHibernateRepositoryContext)context;
        }

        public override void Create(TEntry entity) {
            NHContext.GetSession<TEntry>().Save(entity);
        }

        public override void Delete(TEntry entity) {
            var session = NHContext.GetSession<TEntry>();
            session.Delete(entity);
            session.Flush();
            //未手动Flush，如果存在UNIQUE约束，删除某Key再插入同样Key值的记录，将导致Duplicate key错误
        }

        public override void Delete(IList<TEntry> entities) {
            var session = NHContext.GetSession<TEntry>();
            foreach (var entity in entities) {
                session.Delete(entity);
            }
            session.Flush();
            //未手动Flush，如果存在UNIQUE约束，删除某Key再插入同样Key值的记录，将导致Duplicate key错误
        }

        public override void Delete(params Expression<Func<TEntry, Boolean>>[] predicates) {
            IQueryable<TEntry> query = All;
            foreach (var predicate in predicates) {
                query = query.Where(predicate);
            }
            var entities = query.ToList();
            var session = NHContext.GetSession<TEntry>();
            foreach (var entity in entities) {
                session.Delete(entity);
            }
            session.Flush();
        }

        public override void Update(TEntry entity) {
            NHContext.GetSession<TEntry>().Update(entity);
        }

        public override void Update(IList<TEntry> entities) {
            var session = NHContext.GetSession<TEntry>();
            foreach (var entity in entities) {
                session.Update(entity);
            }
            session.Flush();
            //若未手动Flush，当存在UNIQUE约束时，删除某Key再插入同样Key值的记录将导致"Duplicate key"错误
        }

        public override Boolean Exist(params Expression<Func<TEntry, Boolean>>[] predicates) {
            IQueryable<TEntry> query = All;
            foreach (var predicate in predicates) {
                query = query.Where(predicate);
            }
            return query.Count() > 0;
        }

        public override TEntry Retrive(TKey key) {
            return NHContext.GetSession<TEntry>().Get<TEntry>(key);
        }

        public override IList<TEntry> Retrive(String field, IList<TKey> keys) {
            var session = NHContext.GetSession<TEntry>();
            ICriteria criteria = session.CreateCriteria<TEntry>().Add(Restrictions.In(field, keys.ToList()));
            return criteria.List<TEntry>();
        }

        public override IQueryable<TEntry> All {
            get { return NHContext.Of<TEntry>(); }
            //get { return NHibernate.Linq.LinqExtensionMethods.Query<TEntry>(NHContext.Session); }
            //get { return NHContext.Session.Query<TEntry>(); }
        }
    }
}

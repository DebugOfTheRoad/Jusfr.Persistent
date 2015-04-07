using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace Jusfr.Persistent.NH {
    public class NHibernateRepository<TEntry> : Repository<TEntry> where TEntry : class {
        private readonly NHibernateRepositoryContext _context = null;

        public NHibernateRepositoryContext NHContext {
            get { return _context; }
        }

        public NHibernateRepository(IRepositoryContext context)
            : base(context) {
            _context = context as NHibernateRepositoryContext;
            if (_context == null) {
                throw new ArgumentOutOfRangeException("context",
                    "Expect NHibernateRepositoryContext but provided " + context.GetType().FullName);
            }
        }

        public override IQueryable<TEntry> All {
            get {
                return _context.Of<TEntry>();
            }
        }

        public override TEntry Retrive<TKey>(TKey key) {
            return _context.EnsureSession<TEntry>().Get<TEntry>(key);
        }

        public override IEnumerable<TEntry> Retrive<TKey>(String field, IList<TKey> keys) {
            var session = NHContext.EnsureSession<TEntry>();
            ICriteria criteria = session.CreateCriteria<TEntry>()
                .Add(Restrictions.In(field, keys.ToArray()));
            return criteria.List<TEntry>();
        }

        public override void Create(TEntry entry) {
            _context.EnsureSession<TEntry>().Save(entry);
        }

        public override void Update(TEntry entry) {
            _context.EnsureSession<TEntry>().Update(entry);
        }

        public override void Update(IEnumerable<TEntry> entries) {
            var session = _context.EnsureSession<TEntry>();
            foreach (var entry in entries) {
                session.Update(entry);
            }
            session.Flush();
        }

        public override void Delete(TEntry entry) {
            var session = _context.EnsureSession<TEntry>();
            session.Delete(entry);
            session.Flush();
        }

        public override void Delete(IEnumerable<TEntry> entries) {
            var session = _context.EnsureSession<TEntry>();
            foreach (var entry in entries) {
                session.Delete(entry);
            }
            session.Flush();
        }
    }
}

using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHConfiguration = NHibernate.Cfg.Configuration;

namespace Jusfr.Persistent.NH {
    public class NHibernateRepositoryMultiContext : NHibernateRepositoryContext {
        private Boolean _suspendTransaction = false;
        private readonly Dictionary<ISessionFactory, Func<Type, Boolean>> _sessionFactories;
        private readonly Dictionary<ISessionFactory, ISession> _sessions;
        private ConcurrentDictionary<Type, IQueryable> _queryables;

        public NHibernateRepositoryMultiContext(){
            _queryables = new ConcurrentDictionary<Type, IQueryable>();
            _sessionFactories = new Dictionary<ISessionFactory, Func<Type, Boolean>>();
            _sessions = new Dictionary<ISessionFactory, ISession>();
        }

        protected void Register(ISessionFactory sessionFactory, Func<Type, Boolean> locator) {
            _sessionFactories.Add(sessionFactory, locator);
        }

        public override ISession EnsureSession<TEntry>() {
            var entityType = typeof(TEntry);
            ISessionFactory sessionFactory = null;
            foreach (var locator in _sessionFactories) {
                if (locator.Value(entityType)) {
                    sessionFactory = locator.Key;
                    break;
                }
            }

            if (sessionFactory == null) {
                throw new InvalidOperationException(String.Format("Type '{0}' has no matching configuration", entityType.FullName));
            }

            ISession session = null;
            if (!_sessions.TryGetValue(sessionFactory, out session)) {
                session = sessionFactory.OpenSession();
                _sessions.Add(sessionFactory, session);
            }

            //必须以线程安全的方式调用 NHConfiguration.BuildSessionFactory()

            //如果事务标志已经打开, 则补加事务
            if (_suspendTransaction && !session.Transaction.IsActive) {
                session.BeginTransaction();
            }
            return session;
        }


        public override IQueryable<TEntry> Of<TEntry>() {
            return EnsureSession<TEntry>().Query<TEntry>().Cacheable();
            //return new NhQueryable<TEntry>(GetSession<TEntry>().GetSessionImplementation());
        }

        public override void Begin() {
            _suspendTransaction = true;
            //确保已打开的连接开启事务
            foreach (var session in _sessions) {
                if (!session.Value.Transaction.IsActive) {
                    session.Value.BeginTransaction();
                }
            }
        }

        public override void Rollback() {
            foreach (var session in _sessions) {
                if (session.Value.Transaction.IsActive) {
                    session.Value.Transaction.Rollback();
                    session.Value.Clear();
                }
            }
        }

        public override void Commit() {
            try {
                foreach (var session in _sessions) {
                    if (session.Value.Transaction.IsActive) {
                        session.Value.Transaction.Commit();
                    }
                }
            }
            catch {
                foreach (var session in _sessions) {
                    session.Value.Transaction.Rollback();
                    session.Value.Clear();
                }
                throw;
            }
        }

        protected override void DisposeManaged() {
            try {
                Commit(); //确保隐式事务被提交
            }
            finally {
                for (int i = 0; i < _sessions.Count; i++) {
                }
                foreach (var session in _sessions) {
                    session.Value.Transaction.Dispose();
                    session.Value.Close();
                    session.Value.Dispose();
                }
                _sessions.Clear();
            }
        }
    }
}

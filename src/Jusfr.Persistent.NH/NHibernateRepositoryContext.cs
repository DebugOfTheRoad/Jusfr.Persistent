using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using NHConfiguration = NHibernate.Cfg.Configuration;

namespace Jusfr.Persistent.NH {
    public class NHibernateRepositoryContext : DisposableObject, IRepositoryContext {
        //private static Int32 _index = 0;

        private Boolean _suspendTransaction = false;
        private ISession _session;
        private ISessionFactory _sessionFactory;

        public Guid ID { get; private set; }

        public NHibernateRepositoryContext() {
            ID = Guid.NewGuid();
        }
        protected void Register(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }
        public virtual ISession GetSession<TEntry>() {
            if (_session == null) {
                _session = _sessionFactory.OpenSession();
                //Interlocked.Increment(ref _index);
            }
            if (_suspendTransaction && !_session.Transaction.IsActive) {
                _session.BeginTransaction();
            }
            return _session;
        }

        public virtual IQueryable<TEntry> Of<TEntry>() {
            return new NhQueryable<TEntry>(GetSession<TEntry>().GetSessionImplementation());
        }

        //仅在Session对象已创建, 但事务未创建或已提交的情况下开启新事务
        public virtual void Begin() {
            _suspendTransaction = true;
            if (_session != null && !_session.Transaction.IsActive) {
                _session.BeginTransaction();
            }
        }

        //仅在事务已创建且处于活动中时回滚事务
        public virtual void Rollback() {
            if (_session != null && _session.Transaction.IsActive) {
                _session.Transaction.Rollback();
                _session.Clear();
            }
        }

        //仅在事务已创建且处于活动中时提交事务
        public virtual void Commit() {
            if (_session != null && _session.Transaction.IsActive) {
                try {
                    _session.Transaction.Commit();
                }
                catch {
                    _session.Transaction.Rollback();
                    _session.Clear();
                    throw;
                }
            }
        }

        protected override void DisposeManaged() {
            if (_session != null) {
                //Interlocked.Decrement(ref _index);
                try {
                    Commit(); //确保隐式事务被提交
                }
                finally {
                    _session.Transaction.Dispose();
                    //_session.SessionFactory.Close(); 
                    _session.Close();
                    _session.Dispose();
                    _session = null;
                }
            }
        }
    }
}

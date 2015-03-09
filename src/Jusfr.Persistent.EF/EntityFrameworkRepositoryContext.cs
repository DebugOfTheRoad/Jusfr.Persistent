using Jusfr.Persistent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jusfr.Persistent.EF {
    public class EntityFrameworkRepositoryContext : DisposableObject, IRepositoryContext {
        private DbContextTransaction _trans;
        public Guid ID { get; private set; }
        private Lazy<DbContext> _dbContext;
        private static Int32 index = 0;

        public DbContext DBContext {
            get {
                return _dbContext.Value;
            }
        }

        public EntityFrameworkRepositoryContext() {
            String connectionString = "?";
            ID = Guid.NewGuid();
            _dbContext = new Lazy<DbContext>(() => {
                var dbContext = new DbContext(connectionString);
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                _trans = dbContext.Database.BeginTransaction();
                Interlocked.Increment(ref index);
                return dbContext;
            });
        }

        public void Begin() {
            if (_dbContext.IsValueCreated && _trans == null) {
                _trans = _dbContext.Value.Database.BeginTransaction();
            }
        }

        public void Rollback() {
            if (_trans != null) {
                _trans.Rollback();
                _trans.Dispose();
                _trans = null;
            }
        }

        public void Commit() {
            if (_trans != null) {
                try {
                    _trans.Commit();
                }
                catch {
                    _trans.Rollback();
                    throw;
                }
                finally {
                    _trans.Dispose();
                    _trans = null;
                }
            }
        }

        protected override void DisposeManaged() {
            if (_dbContext.IsValueCreated) {
                Interlocked.Decrement(ref index);
                try {
                    Commit();
                }
                finally {
                    _dbContext.Value.Dispose();
                }
            }
        }
    }
}

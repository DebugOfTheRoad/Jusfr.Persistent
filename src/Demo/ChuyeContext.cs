using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jusfr.Persistent.NH;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.ConfigurationSchema;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Demo {
    class ChuyeContext : NHibernateRepositoryContext {
        private static readonly ISessionFactory _dbFactory;

        static ChuyeContext() {
            _dbFactory = BuildSessionFactory();
        }

        public ChuyeContext() {
            Register(_dbFactory);
        }

        private static ISessionFactory BuildSessionFactory() {
            var dbConStr = System.Configuration.ConfigurationManager.ConnectionStrings["Chuye"].ConnectionString;
            var dbFluentConfig = Fluently.Configure()
                   .Database(MySQLConfiguration.Standard.ConnectionString(dbConStr))
                   .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>());
            var dbConfig = dbFluentConfig.BuildConfiguration();
            dbConfig.SetInterceptor(new NHibernateInterceptor());
            return dbConfig.BuildSessionFactory();
        }
    }
}

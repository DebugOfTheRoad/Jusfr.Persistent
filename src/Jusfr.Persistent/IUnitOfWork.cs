using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent {
    public interface IUnitOfWork : IDisposable {
        void Begin();
        void Rollback();
        void Commit();
    }
}

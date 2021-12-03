using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task DisposeAsync();
    }
}

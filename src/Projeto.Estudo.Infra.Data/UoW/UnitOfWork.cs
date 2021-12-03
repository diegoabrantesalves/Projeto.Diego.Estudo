using ClearSale.Estudo.Infra.Data.Contexts;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSale.Estudo.Infra.Data.EntityFramework.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

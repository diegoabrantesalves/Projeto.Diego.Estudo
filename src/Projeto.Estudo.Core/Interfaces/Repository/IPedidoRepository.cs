using Projeto.Estudo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        public Task<Pedido> GetAsync(long pedidoId);
        public Task<List<Pedido>> GetAllAsync();
        public Task SaveAsync(Pedido pedido);
        public Task PutAsync(Pedido pedido);
    }
}

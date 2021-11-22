using Projeto.Estudo.Core.Entities;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSale.Estudo.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public Task<List<Pedido>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetAsync(long pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}

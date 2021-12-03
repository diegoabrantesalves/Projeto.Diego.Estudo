using ClearSale.Estudo.Infra.Data.Contexts;
using ClearSale.Estudo.Infra.Data.EntityFramework.Repository;
using Projeto.Estudo.Core.Entities;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSale.Estudo.Infra.Data.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApiContext context)
            : base(context)
        {

        }

    }
}

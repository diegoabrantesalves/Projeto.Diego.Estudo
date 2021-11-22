using ClearSale.Estudo.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Estudo.Core.Handlers;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearSale.Estudo.Infra.CrossCutting.IoC
{

    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Handler
            services.AddTransient<PedidoHandler>();
            #endregion

            #region Services

            #endregion


            #region Repository
            services.AddSingleton<IPedidoRepository, PedidoRepository>();
            #endregion
        }
    }
}

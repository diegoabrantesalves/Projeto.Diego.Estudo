using ClearSale.Estudo.Infra.Data.EntityFramework.UoW;
using ClearSale.Estudo.Infra.Data.Repository;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Estudo.Core.Commands.Pedido;
using Projeto.Estudo.Core.Handlers;
using Projeto.Estudo.Core.Interfaces.Repository;
using Projeto.Estudo.Core.Services;
using Projeto.Estudo.Core.Validations.Pedido;
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
            services.AddScoped<PedidoHandler>();
            #endregion

            #region Validations
            services.AddTransient<IValidator<CriarPedidoCommand>, CriarPedidoCommandValidator>();
            services.AddTransient<IValidator<AlterarPedidoCommand>, AlterarPedidoCommandValidator>();
            #endregion

            #region Services
            services.AddScoped<PedidoService, PedidoService>();
            #endregion

            #region Repository
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}

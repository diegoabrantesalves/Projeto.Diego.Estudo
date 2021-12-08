using Microsoft.AspNetCore.Mvc;
using Projeto.Estudo.Api.Controllers;
using Projeto.Estudo.Api.ViewModels;
using Projeto.Estudo.Core.Commands;
using Projeto.Estudo.Core.Commands.Pedido;
using Projeto.Estudo.Core.Entities;
using Projeto.Estudo.Core.Handlers;
using Projeto.Estudo.Core.Interfaces.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace Projeto.Diego.Api.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly PedidoHandler _pedidoHandler;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(PedidoHandler pedidoHandler, IPedidoRepository pedidoRepository)
        {
            _pedidoHandler = pedidoHandler;
            _pedidoRepository = pedidoRepository;
        }

        [SwaggerOperation(
        Summary = "Cadastro de Pedidos",
        Description = "Cadastro de pedidos",
        OperationId = "pedidos.Post",
        Tags = new[] { "PedidosEndpoints" })]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PedidoViewModel pedidoViewModel)
            => Response(await _pedidoHandler.HandleAsync(new CriarPedidoCommand(pedidoViewModel.Nome, pedidoViewModel.DataRegistro)));

        [SwaggerOperation(
        Summary = "Alteracão de Pedidos",
        Description = "Alteracão de pedidos",
        OperationId = "pedidos.Put",
        Tags = new[] { "PedidosEndpoints" })]
        [HttpPut("{pedidoId:long}")]
        public async Task<IActionResult> PutAsync([FromRoute] long pedidoId, [FromBody] PedidoViewModel pedidoViewModel)
            => Response(await _pedidoHandler.HandleAsync(new AlterarPedidoCommand(pedidoId, pedidoViewModel.Nome, pedidoViewModel.DataRegistro)));

        [SwaggerOperation(
        Summary = "Busca um pedido",
        Description = "Busca de um pedido",
        OperationId = "pedidos.Get",
        Tags = new[] { "PedidosEndpoints" })]
        [HttpGet("{pedidoId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long pedidoId)
            => Response(await _pedidoRepository.GetByIdAsync(pedidoId));

        [SwaggerOperation(
       Summary = "Deleta um pedido",
       Description = "Deleta de um pedido",
       OperationId = "pedidos.Delete",
       Tags = new[] { "PedidosEndpoints" })]
        [HttpDelete("{pedidoId:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long pedidoId)
           => Response(await _pedidoRepository.DeleteAsync(pedidoId));

        [SwaggerOperation(
        Summary = "Lista de Pedidos",
        Description = "Lista de pedidos",
        OperationId = "pedidos.List",
        Tags = new[] { "PedidosEndpoints" })]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
             => Response(await _pedidoRepository.GetAsync());
    }
}
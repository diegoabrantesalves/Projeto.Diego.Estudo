using Microsoft.AspNetCore.Mvc;
using Projeto.Estudo.Core.Commands;
using Projeto.Estudo.Core.Entities;
using Projeto.Estudo.Core.Handlers;
using Projeto.Estudo.Core.Interfaces.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace Projeto.Diego.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly PedidoHandler _pedidoHandler;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(ILogger<PedidosController> logger,
            PedidoHandler pedidoHandler, IPedidoRepository pedidoRepository)
        {
            _logger = logger;
            _pedidoHandler = pedidoHandler;
            _pedidoRepository = pedidoRepository;
        }

        [SwaggerOperation(
        Summary = "Cadastro de Pedidos",
        Description = "Cadastro de pedidos",
        OperationId = "pedidos.Post",
        Tags = new[] { "PedidosEndpoints" })]
        [HttpPost(Name = "Pedidos")]
        public async Task<IActionResult> PostAsync()
            => Ok(await _pedidoHandler.HandleAsync(new CriarPedidoCommand()));

        [SwaggerOperation(
        Summary = "Alteracão de Pedidos",
        Description = "Alteracão de pedidos",
        OperationId = "pedidos.Put",
        Tags = new[] { "PedidosEndpoints" })
    ]
        [HttpPost(Name = "Pedidos")]
        public async Task<IActionResult> PutAsync()
            => Ok(await _pedidoHandler.HandleAsync(new AlterarPedidoCommand()));

        [SwaggerOperation(
        Summary = "Lista de Pedidos",
        Description = "Lista de pedidos",
        OperationId = "pedidos.List",
        Tags = new[] { "PedidosEndpoints" })
        ]
        [HttpGet(Name = "Pedidos")]
        public async Task<IActionResult> GetAsync([FromRoute] long pedidoId)
            => Ok(await _pedidoRepository.GetAsync(pedidoId));        

        [SwaggerOperation(
       Summary = "Busca um pedido",
       Description = "Busca de um pedido",
       OperationId = "pedidos.Get",
       Tags = new[] { "PedidosEndpoints" })       ]
        [HttpGet(Name = "Pedidos")]
        public async Task<IActionResult> GetAsync()
             => Ok(await _pedidoRepository.GetAllAsync());
    }
}
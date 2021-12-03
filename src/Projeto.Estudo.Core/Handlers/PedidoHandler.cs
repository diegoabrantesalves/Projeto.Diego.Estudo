using Projeto.Estudo.Core.Commands.Pedido;
using Projeto.Estudo.Core.Commands.Contracts;
using Projeto.Estudo.Core.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Estudo.Core.Interfaces.Repository;
using Projeto.Estudo.Core.Commands;
using Projeto.Estudo.Core.Entities;
using Projeto.Estudo.Core.Validations.Pedido;
using Microsoft.Extensions.Logging;

namespace Projeto.Estudo.Core.Handlers
{
    public class PedidoHandler : IHandler<CriarPedidoCommand>, IHandler<AlterarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly CriarPedidoCommandValidation _criarPedidoCommandValidation;
        private readonly AlterarPedidoCommandValidation _alterarPedidoCommandValidation;
        private readonly ILogger<PedidoHandler> _logger;
        public PedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork uow, ILogger<PedidoHandler> logger)
        {
            _pedidoRepository = pedidoRepository;
            _uow = uow;
            _logger = logger;
            _criarPedidoCommandValidation = new CriarPedidoCommandValidation(_pedidoRepository);
            _alterarPedidoCommandValidation = new AlterarPedidoCommandValidation(_pedidoRepository);
        }

        public async Task<ICommandResult> HandleAsync(CriarPedidoCommand command)
        {
            try
            {
                var validation = await _criarPedidoCommandValidation.ValidateAsync(command);
                if (!validation.IsValid)
                {
                    return new GenericCommandResult(false);
                }

                await _pedidoRepository.InsertAsync(new Pedido() { Nome = command.Nome, DataRegistro = command.Data });
                await _uow.CommitAsync();

                return new GenericCommandResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir pedido " + command.Nome);
                await _uow.DisposeAsync();
                return new GenericCommandResult(false);
            }
        }

        public async Task<ICommandResult> HandleAsync(AlterarPedidoCommand command)
        {
            try
            {
                var validation = await _alterarPedidoCommandValidation.ValidateAsync(command);
                if (!validation.IsValid)
                {
                    return new GenericCommandResult(false);
                }

                _pedidoRepository.Update(new Pedido() { Id = command.Id, Nome = command.Nome, DataRegistro = command.Data });
                await _uow.CommitAsync();

                return new GenericCommandResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar pedido " + command.Id);
                await _uow.DisposeAsync();
                return new GenericCommandResult(false);
            }
        }
    }
}

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
using FluentValidation;

namespace Projeto.Estudo.Core.Handlers
{
    public class PedidoHandler : IHandler<CriarPedidoCommand>, IHandler<AlterarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CriarPedidoCommand> _criarPedidoCommandValidator;
        private readonly IValidator<AlterarPedidoCommand> _alterarPedidoCommandValidator;
        private readonly ILogger<PedidoHandler> _logger;
        public PedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork uow, ILogger<PedidoHandler> logger,
            IValidator<CriarPedidoCommand> criarPedidoCommandValidator, IValidator<AlterarPedidoCommand> alterarPedidoCommandValidator)
        {
            _pedidoRepository = pedidoRepository;
            _uow = uow;
            _logger = logger;
            _criarPedidoCommandValidator = criarPedidoCommandValidator;
            _alterarPedidoCommandValidator = alterarPedidoCommandValidator;
        }

        public async Task<ICommandResult> HandleAsync(CriarPedidoCommand command)
        {
            try
            {
                var validation = await _criarPedidoCommandValidator.ValidateAsync(command);
                if (!validation.IsValid)
                    return new GenericCommandResult(false, validation);

                var pedido = await _pedidoRepository.InsertAsync(new Pedido() { Nome = command.Nome, DataRegistro = command.Data });
                await _uow.CommitAsync();

                return new GenericCommandResult(true, pedido);
            }
            catch (Exception ex)
            {
                await _uow.DisposeAsync();
                _logger.LogError(ex, $"Erro ao inserir o pedido {command.Nome}");
                throw new Exception($"Erro ao inserir o pedido {command.Nome}, entre em contato com o suporte!");
            }
        }

        public async Task<ICommandResult> HandleAsync(AlterarPedidoCommand command)
        {
            try
            {
                var validation = await _alterarPedidoCommandValidator.ValidateAsync(command);
                if (!validation.IsValid)
                    return new GenericCommandResult(false, validation);

                var pedido = new Pedido() { Id = command.Id, Nome = command.Nome, DataRegistro = command.Data };
                _pedidoRepository.Update(pedido);
                await _uow.CommitAsync();

                return new GenericCommandResult(true, pedido);
            }
            catch (Exception ex)
            {
                await _uow.DisposeAsync();
                _logger.LogError(ex, $"Erro ao alterar o pedido {command?.Id}");
                throw new Exception($"Erro ao alterar o pedido {command?.Id}, entre em contato com o suporte!");
            }
        }
    }
}

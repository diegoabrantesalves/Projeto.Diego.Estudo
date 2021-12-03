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

namespace Projeto.Estudo.Core.Handlers
{
    public class PedidoHandler : IHandler<CriarPedidoCommand>, IHandler<AlterarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly CriarPedidoCommandValidation _criarPedidoCommandValidation;
        private readonly AlterarPedidoCommandValidation _alterarPedidoCommandValidation;
        public PedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork uow)
        {
            _pedidoRepository = pedidoRepository;
            _uow = uow;
            _criarPedidoCommandValidation = new CriarPedidoCommandValidation(_pedidoRepository);
            _alterarPedidoCommandValidation = new AlterarPedidoCommandValidation(_pedidoRepository);
        }

        public async Task<ICommandResult> HandleAsync(CriarPedidoCommand command)
        {
            var validation = await _criarPedidoCommandValidation.ValidateAsync(command);
            if (!validation.IsValid)
            {
                return new GenericCommandResult(false);
            }

            await _pedidoRepository.InsertAsync(new Pedido() { Nome = command.Nome, DataRegistro = command.Data });
            _uow.Commit();

            return new GenericCommandResult(true);
        }

        public async Task<ICommandResult> HandleAsync(AlterarPedidoCommand command)
        {
            var validation = await _alterarPedidoCommandValidation.ValidateAsync(command);
            if (!validation.IsValid)
            {
                return new GenericCommandResult(false);
            }

            _pedidoRepository.Update(new Pedido() { Id = command.Id, Nome = command.Nome, DataRegistro = command.Data });
            _uow.Commit();

            return new GenericCommandResult(true);
        }
    }
}

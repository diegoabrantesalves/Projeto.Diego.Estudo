using Projeto.Estudo.Core.Commands;
using Projeto.Estudo.Core.Commands.Contracts;
using Projeto.Estudo.Core.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Handlers
{
    public class PedidoHandler : IHandler<CriarPedidoCommand>, IHandler<AlterarPedidoCommand>
    {
        public async Task<ICommandResult> HandleAsync(CriarPedidoCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> HandleAsync(AlterarPedidoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

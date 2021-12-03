using Projeto.Estudo.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Commands.Pedido
{
    public class AlterarPedidoCommand : ICommand
    {
        public AlterarPedidoCommand() { }

        public AlterarPedidoCommand(long id, string nome, DateTime data)
        {
            Id = id;
            Nome = nome;
            Data = data;
        }
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}

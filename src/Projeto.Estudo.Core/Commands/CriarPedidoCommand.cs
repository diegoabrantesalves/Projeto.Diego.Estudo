using Projeto.Estudo.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Commands
{
    public class CriarPedidoCommand : ICommand
    {
        public CriarPedidoCommand() { }

        public CriarPedidoCommand(string nome, DateTime data)
        {
            Nome = nome;
            Data = data;
        }

        public string? Nome { get; set; }
        public DateTime Data { get; set; }

        public void Validate()
        {
           
        }
    }
}

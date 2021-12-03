using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Entities
{
    public class Pedido
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}

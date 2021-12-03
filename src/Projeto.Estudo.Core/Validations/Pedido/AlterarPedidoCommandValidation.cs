using FluentValidation;
using Projeto.Estudo.Core.Commands.Pedido;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Validations.Pedido
{
    public class AlterarPedidoCommandValidation : AbstractValidator<AlterarPedidoCommand>
    {
        public AlterarPedidoCommandValidation(IPedidoRepository pedidoRepository)
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters")
                .MustAsync(async (nome, cancellation) =>
                {
                    var exists = await pedidoRepository.GetAsync(x => x.Nome == nome);
                    return !exists.Any();
                })
                .WithMessage("Nome deve ser unico");
        }
    }
}

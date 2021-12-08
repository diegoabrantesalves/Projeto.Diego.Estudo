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
    public class AlterarPedidoCommandValidator : AbstractValidator<AlterarPedidoCommand>
    {
        public AlterarPedidoCommandValidator(IPedidoRepository pedidoRepository)
        {
            RuleFor(c => c.Id)
                .MustAsync(async (id, cancellation) =>
                {
                    var exists = await pedidoRepository.GetAsync(x => x.Id == id);
                    return exists.Any();
                })
                .WithMessage("Pedido não existe");

            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O nome não pode ficar em branco")
               .Length(2, 150).WithMessage("O nome tem que estar entre 2 e 150 caracteres");

            RuleFor(c => c)
               .MustAsync(async (pedido, cancellation) =>
               {
                   var exists = await pedidoRepository.GetAsync(x => x.Nome == pedido.Nome && x.Id != pedido.Id);
                   return !exists.Any();
               })
               .WithMessage("Nome do pedido deve ser único");
        }
    }
}

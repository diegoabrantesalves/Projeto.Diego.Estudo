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
    public class CriarPedidoCommandValidator : AbstractValidator<CriarPedidoCommand>
    {
        public CriarPedidoCommandValidator(IPedidoRepository pedidoRepository)
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome não pode ficar em branco")
                .Length(2, 150).WithMessage("O nome tem que estar entre 2 e 150 caracteres")                
                .MustAsync(async (nome, cancellation) =>
                {
                    var exists = await pedidoRepository.GetAsync(x => x.Nome == nome);
                    return !exists.Any();
                })
                .WithMessage("Nome do pedido deve ser único");
        }

    }
}

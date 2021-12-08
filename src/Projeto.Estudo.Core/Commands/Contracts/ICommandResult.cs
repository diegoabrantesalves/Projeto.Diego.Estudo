using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Commands.Contracts
{
    public interface ICommandResult
    {
        public bool Success { get; set; }
        public ValidationResult? ValidationResult { get; set; }
        public object? Data { get; set; }
    }
}

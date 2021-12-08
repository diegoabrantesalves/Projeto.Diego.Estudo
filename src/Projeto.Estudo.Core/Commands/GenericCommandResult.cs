using FluentValidation.Results;
using Projeto.Estudo.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool success, ValidationResult? validationResult = null)
        {
            Success = success;
            ValidationResult = validationResult;
        }

        public GenericCommandResult(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; set; }
        public ValidationResult? ValidationResult { get; set; }
        public object? Data { get; set; }
    }
}

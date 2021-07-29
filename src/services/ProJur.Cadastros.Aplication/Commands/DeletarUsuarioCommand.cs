using FluentValidation;
using FluentValidation.Results;
using ProJur.Core.Messages;
using System;

namespace ProJur.Cadastros.Aplication.Commands
{
    public class DeletarUsuarioCommand : Command
    {
        public Guid Id { get; private set; }        
        public ValidationResult ValidationResult { get; protected set; }

        public DeletarUsuarioCommand(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            var erros = new DeletarUsuarioCommandValidation().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }    

    public class DeletarUsuarioCommandValidation : AbstractValidator<DeletarUsuarioCommand>
    {
        public DeletarUsuarioCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O Id é obrigatório");                
          
        }
    }
}

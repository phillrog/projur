using FluentValidation;
using FluentValidation.Results;
using ProJur.Core.DomainObjects;
using System;

namespace ProJur.Cadastros.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Escolaridade Escolaridade { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        internal bool EhValido()
        {
            var erros = new UsuarioValidation().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }

    public enum Escolaridade
    {
        Infantil = 0, 
        Fundamental = 1, 
        Medio = 2,
        Superior = 3
    }

    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail válido é obrigatório");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("Data de nascimento é obrigatório")
                .Must(DataValida).WithMessage("Data de nascimento deve ser válida")
                .Must(NaoPodeSerMaior).WithMessage("Data Nascimento não pode ser maqior que hoje");

            RuleFor(c => c.Escolaridade).IsInEnum()
                .WithMessage("Informe uma escolaridade válida");
        }

        private bool DataValida(DateTime data)
        {
            return !data.Equals(default(DateTime));
        }

        private bool NaoPodeSerMaior(DateTime data)
        {
            return (data > DateTime.Today) ? true : false;
        }
    }
}

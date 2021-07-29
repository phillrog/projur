using FluentValidation;
using FluentValidation.Results;
using ProJur.Core.DomainObjects;
using System;

namespace ProJur.Cadastros.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public ValidationResult ValidationResult { get; protected set; }
                
        public bool EhValido()
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
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(c => c.SobreNome)
                .NotEmpty().WithMessage("Sobrenome é obrigatório");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(c => c.DataNascimento)
                .NotNull().WithMessage("Data de nascimento é obrigatório")
                .Must(DataValida).WithMessage("Data de nascimento deve ser válida")
                .Must(NaoPodeSerMaior).WithMessage("Data Nascimento não pode ser maior que hoje");

            RuleFor(c => c.Escolaridade).IsInEnum()
                .WithMessage("Informe uma escolaridade válida");
        }

        private bool DataValida(DateTime data)
        {
            return !data.Equals(default(DateTime));
        }

        private bool NaoPodeSerMaior(DateTime data)
        {
            return (data <= DateTime.Today) ? true : false;
        }
    }
}

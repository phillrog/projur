using FluentValidation;
using FluentValidation.Results;
using ProJur.Cadastros.Domain;
using ProJur.Core.Messages;
using System;

namespace ProJur.Cadastros.Aplication.Commands
{
    public class AdicionarUsuarioCommand : Command
    {
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Escolaridade Escolaridade { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        public AdicionarUsuarioCommand(string nome, string sobreNome, string email, DateTime dataNascimento, int escolaridade)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = (Escolaridade)escolaridade;
        }

        public override bool EhValido()
        {
            var erros = new AdicionarUsuarioCommandValidation().Validate(this).Errors;
            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }    

    public class AdicionarUsuarioCommandValidation : AbstractValidator<AdicionarUsuarioCommand>
    {
        public AdicionarUsuarioCommandValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(250);

            RuleFor(c => c.SobreNome)
                .NotEmpty().WithMessage("Sobrenome é obrigatório")
                .MaximumLength(250); 

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido")
                .MaximumLength(250); 

            RuleFor(c => c.DataNascimento)
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

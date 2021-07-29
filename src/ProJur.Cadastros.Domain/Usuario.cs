using FluentValidation;
using FluentValidation.Results;
using ProJur.Core.DomainObjects;
using System;

namespace ProJur.Cadastros.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Escolaridade Escolaridade { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string sobreNome, string email, DateTime dataNascimento, int escolaridade)
        {
            Nome = nome;
            Sobrenome = sobreNome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = (Escolaridade)escolaridade;
        }
    }

    public enum Escolaridade
    {
        Infantil = 0,
        Fundamental = 1,
        Medio = 2,
        Superior = 3
    }   
}

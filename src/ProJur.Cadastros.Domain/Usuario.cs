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

    }

    public enum Escolaridade
    {
        Infantil = 0, 
        Fundamental = 1, 
        Medio = 2,
        Superior = 3
    }
}

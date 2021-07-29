using System;

namespace ProJur.Cadastros.Aplication.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Escolaridade { get; private set; }
    }
}

using System;

namespace ProJur.Cadastros.Aplication.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }
        public string EscolaridadeDesc { get; set; }
    }
}

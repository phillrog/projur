using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }   

        public async Task<bool> UsuarioJaCadastroAsync(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);

            return (usuario != null && usuario.Id != null);
        }
    }
}

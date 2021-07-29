using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Domain
{
    public interface IUsuarioService
    {
        Task<bool> UsuarioJaCadastroAsync(string email);
    }
}

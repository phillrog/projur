using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Domain.Service
{
    public interface IUsuarioService
    {
        Task<bool> UsuarioJaCadastroAsync(string email);
    }
}

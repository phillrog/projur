using ProJur.Cadastros.Aplication.ViewModels;
using ProJur.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Aplication.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> UsuarioJaCadastradoAsync(string email);
    }
}

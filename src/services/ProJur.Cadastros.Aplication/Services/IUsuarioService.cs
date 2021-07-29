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
        Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync();
        Task<UsuarioViewModel> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Usuario usuario);
        Task<bool> UsuarioJaCadastradoAsync(string email);
        Task<bool> UsuarioExisteAsync(Guid id);
    }
}

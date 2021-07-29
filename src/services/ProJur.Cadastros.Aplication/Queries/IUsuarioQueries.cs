using ProJur.Cadastros.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Aplication.Queries
{
    public interface IUsuarioQueries
    {
        Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync();
        Task<UsuarioViewModel> ObterPorIdAsync(Guid id);
    }
}

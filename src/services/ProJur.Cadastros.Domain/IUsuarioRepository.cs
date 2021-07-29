using ProJur.Core.Data;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterPorEmailAsync(string email);
    }
}

using ProJur.Cadastros.Domain;

using System.Linq;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(UsuarioContext db) : base(db)
        {
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            var usuario = await BuscarAsync(d => d.Email == email);
            return usuario.FirstOrDefault();
        }
    }
}

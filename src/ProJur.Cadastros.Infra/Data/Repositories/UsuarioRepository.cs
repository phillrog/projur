using ProJur.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProJur.Cadastros.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(UsuarioContext db) : base(db)
        {
        }
    }
}

using MediatR;
using ProJur.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Aplication.Commands
{
    public class UsuarioCommandHandler :
        IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        public async Task<bool> Handle(AdicionarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;
            throw new NotImplementedException();
        }

        private bool ValidarComando(Command usuario)
        {
            if (usuario.EhValido()) return true;

            
            return false;
        }
    }
}

using MediatR;
using ProJur.Core.Messages;
using System.Threading;
using System.Threading.Tasks;
using ProJur.Cadastros.Domain;
using FluentValidation.Results;

namespace ProJur.Cadastros.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<AdicionarUsuarioCommand, ValidationResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return message.ValidationResult ;

            var novoUsuario = Usuario
                .UsuarioFactory
                .NovoUsuario(message.Nome, message.SobreNome, message.Email, message.DataNascimento, message.Escolaridade);

            await _usuarioRepository.AdicionarAsync(novoUsuario);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private bool ValidarComando(Command usuario)
        {
            if (usuario.EhValido()) return true;

            
            return false;
        }
    }
}

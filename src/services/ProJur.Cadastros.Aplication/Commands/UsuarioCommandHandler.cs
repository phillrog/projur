using MediatR;
using ProJur.Core.Messages;
using System.Threading;
using System.Threading.Tasks;
using ProJur.Cadastros.Domain;
using FluentValidation.Results;

namespace ProJur.Cadastros.Aplication.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<AdicionarUsuarioCommand, ValidationResult>,
        IRequestHandler<AtualizarUsuarioCommand, ValidationResult>,
        IRequestHandler<DeletarUsuarioCommand, ValidationResult>
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
                .NovoUsuario(message.Nome, message.SobreNome, message.Email, message.DataNascimento, (int)message.Escolaridade);

            await _usuarioRepository.AdicionarAsync(novoUsuario);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return message.ValidationResult;

            var usuario = await _usuarioRepository.ObterPorIdAsync(message.Id);

            var usuarioAtualizado = Usuario.UsuarioFactory.AtualizarUsuario(usuario.Id, message.Nome, message.SobreNome, message.Email, message.DataNascimento, (int)message.Escolaridade);

            await _usuarioRepository.AtualizarAsync(usuarioAtualizado);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeletarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return message.ValidationResult;

            await _usuarioRepository.RemoverAsync(message.Id);

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }

        private bool ValidarComando(Command usuario)
        {
            if (usuario.EhValido()) return true;

            
            return false;
        }
    }
}

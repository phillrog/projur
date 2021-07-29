using AutoMapper;
using ProJur.Cadastros.Aplication.ViewModels;
using ProJur.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Aplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _usuarioRepository.AdicionarAsync(usuario);
            await _usuarioRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _usuarioRepository.AtualizarAsync(usuario);
            await _usuarioRepository.UnitOfWork.Commit();
        }


        public async Task<UsuarioViewModel> ObterPorIdAsync(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorIdAsync(id));
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodosAsync());
        }

        public async Task Remover(Usuario usuario)
        {
            await _usuarioRepository.RemoverAsync(usuario.Id);
            await _usuarioRepository.UnitOfWork.Commit();
        }
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}

using AutoMapper;
using ProJur.Cadastros.Aplication.ViewModels;
using ProJur.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainServices = ProJur.Cadastros.Domain.Services;

namespace ProJur.Cadastros.Aplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly DomainServices.IUsuarioService _usuarioServiceDomain;

        public UsuarioService(IUsuarioRepository usuarioRepository,
            IMapper mapper,
            DomainServices.IUsuarioService usuarioServiceDomain)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioServiceDomain = usuarioServiceDomain;
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

        public async Task<bool> UsuarioJaCadastradoAsync(string email)
        {
            return await _usuarioServiceDomain.UsuarioJaCadastroAsync(email);
        }

        public async Task<bool> UsuarioExisteAsync(Guid id)
        {
            if (id == Guid.Empty) return false;

            var usuario = await _usuarioRepository.ObterPorIdAsync(id);

            return usuario != null && usuario.Id != Guid.Empty;
        }
    }
}

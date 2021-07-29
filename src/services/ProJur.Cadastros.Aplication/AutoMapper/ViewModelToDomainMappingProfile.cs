using AutoMapper;
using ProJur.Cadastros.Aplication.Commands;
using ProJur.Cadastros.Aplication.ViewModels;
using ProJur.Cadastros.Domain;

namespace ProJur.Cadastros.Aplication.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(u =>
                    new Usuario(u.Nome, u.SobreNome, u.Email, u.DataNascimento, u.Escolaridade));

            CreateMap<UsuarioViewModel, AdicionarUsuarioCommand>()
                .ConstructUsing(u =>
                    new AdicionarUsuarioCommand(u.Nome, u.SobreNome, u.Email, u.DataNascimento, u.Escolaridade));

            CreateMap<UsuarioViewModel, AtualizarUsuarioCommand>()
                .ConstructUsing(u =>
                    new AtualizarUsuarioCommand(u.Id, u.Nome, u.SobreNome, u.Email, u.DataNascimento, u.Escolaridade));
        }
    }
}
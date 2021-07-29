using AutoMapper;
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
        }
    }
}
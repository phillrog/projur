using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProJur.Cadastros.Aplication.ViewModels;
using ProJur.Cadastros.Domain;

namespace ProJur.Cadastros.Aplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}

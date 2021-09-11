using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class UsuarioPushTokenProfile : Profile
    {
        public UsuarioPushTokenProfile()
        {

            //CreateMap<Accesos, AccesosDto>();
            CreateMap<UsuarioPushTokenDto, UsuarioPushToken>();
            CreateMap<UsuarioPushToken, UsuarioPushTokenDto>(); 
        }
    }
}

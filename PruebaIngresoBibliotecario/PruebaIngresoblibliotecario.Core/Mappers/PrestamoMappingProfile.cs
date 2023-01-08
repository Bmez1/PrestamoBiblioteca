using AutoMapper;
using PruebaIngresoblibliotecario.Core.DTOs;
using PruebaIngresoblibliotecario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoblibliotecario.Core.Mappers
{
    public class PrestamoMappingProfile : Profile
    {
        public PrestamoMappingProfile()
        {
            CreateMap<PrestamoDTO, Prestamo>().ReverseMap();
        }

    }
}

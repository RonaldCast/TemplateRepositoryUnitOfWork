using AutoMapper;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateUnitWorkRepository.DTO;

namespace TemplateUnitWorkRepository.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DTOUser>().ReverseMap(); ;
            CreateMap<Product, DTOProduct>().ReverseMap(); ;
        }
    }
}

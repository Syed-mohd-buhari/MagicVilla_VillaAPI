using AutoMapper;
using MagicVilla_WEB.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicVilla_WEB
{
    public class MappingConfig : Profile 
    {
        public MappingConfig()
        { 
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

			CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
			CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();





		}
    }
}

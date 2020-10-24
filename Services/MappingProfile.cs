using AutoMapper;
using Doska.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doska.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdsModel, AdsCreateModel>().ReverseMap();
            CreateMap<AdsCreateModel, Ads>().ReverseMap();

        }
    }
}

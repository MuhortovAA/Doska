using AutoMapper;
using Doska.Models;
using Doska.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
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
            CreateMap<ViewModel, IdentityUser>().ReverseMap();
            CreateMap<EditModel, IdentityUser>().ReverseMap();
            //CreateMap<IdentityUser, EditModel>().ReverseMap();




        }
    }
}

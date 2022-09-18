using AmanaTechnology.Dto;
using AmanaTechnology.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology
{
    public class AmanaAutoMapper:Profile
    {
        public AmanaAutoMapper()
        {
            CreateMap<CreateOrEditeDto, Blogs>().ReverseMap();
            CreateMap<Blogs, GetAllBlogsDto>();
        }

    }
}

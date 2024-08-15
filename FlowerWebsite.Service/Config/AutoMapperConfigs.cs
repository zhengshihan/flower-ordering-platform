using AutoMapper;
using FlowerWebsite.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Service.Config
{
    public class AutoMapperConfigs: Profile
    {
        public AutoMapperConfigs() 
        {
            CreateMap<Flower,FlowerRes>();
            CreateMap<User,UserRes>();
            CreateMap<RegisterReq, User>();

        }
    }
}

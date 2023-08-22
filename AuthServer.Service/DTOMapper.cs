using AuthServer.Core.DTO_s;
using AuthServer.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<ProductDTO,Product>().ReverseMap();
            CreateMap<UserAppDTO, UserApp>().ReverseMap();
        }
    }
}

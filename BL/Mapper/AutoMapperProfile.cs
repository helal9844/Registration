using AutoMapper;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO,User>();

            CreateMap<User, UserWriteDTO>();
            CreateMap<UserWriteDTO,User > ();

            CreateMap<CountryDTO, UserCountry>();
            CreateMap<UserCountry, CountryDTO>();

        }
    }
}

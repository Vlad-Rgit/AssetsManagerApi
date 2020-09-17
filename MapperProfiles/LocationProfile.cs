using AutoMapper;
using KazanNeftApi.DTO;
using KazanNeftApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.MapperProfiles
{
    public class LocationProfile: Profile
    {
        public LocationProfile()
        {
            CreateMap<Locations, LocationDTO>()
                .ReverseMap();
        }
    }
}

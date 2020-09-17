using AutoMapper;
using KazanNeftApi.DTO;
using KazanNeftApi.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.Controllers
{
    public class LocationController: ApiControllerBase
    {
        public LocationController(KazanNeftContext context, IMapper mapper)
            : base(context, mapper) { }

        [HttpGet]
        [Route("/locations")]
        public IActionResult GetLocations()
        {
            var locations = _context.Locations.ToList();
            var transferList =
                _mapper.Map<List<LocationDTO>>(locations);
            return new JsonResult(transferList);
        }
    }
}

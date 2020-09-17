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
    public class DepartmentLocationController: ApiControllerBase
    {
        public DepartmentLocationController(KazanNeftContext context, IMapper mapper)
                : base(context, mapper) { }

        [HttpGet]
        [Route("/departmentLocations")]
        public IActionResult GetDepartmentLocations()
        {
            var list = _context.DepartmentLocations.ToList();

            var transferList =
                _mapper.Map<List<DepartmentLocationDTO>>(list);

            return new JsonResult(transferList);
        }
    }
}

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
    public class DepartmentController: ApiControllerBase
    {
        public DepartmentController(KazanNeftContext context, IMapper mapper)
            :base(context, mapper) { }

        [HttpGet]
        [Route("/departments")]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            var transferList = _mapper
                .Map<List<DepartmentDTO>>(departments);

            return new JsonResult(transferList);
        }
    }
}

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
    public class EmployeeController: ApiControllerBase
    {
        public EmployeeController(KazanNeftContext context, IMapper mapper)
               : base(context, mapper) { }


        [HttpGet]
        [Route("/employees")]
        public IActionResult GetEmployees()
        {
            var list = _context.Employees.ToList();

            var transferList
                = _mapper.Map<List<EmployeeDTO>>(list);

            return new JsonResult(transferList);
        }
    }
}

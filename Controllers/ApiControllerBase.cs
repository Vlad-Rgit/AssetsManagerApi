using AutoMapper;
using KazanNeftApi.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.Controllers
{
    /// <summary>
    /// Base class for controller which handles rest api requests 
    /// </summary>
    /// 
    
    [ApiController]
    public abstract class ApiControllerBase: ControllerBase
    {
        protected IMapper _mapper;
        protected KazanNeftContext _context;

        public ApiControllerBase(KazanNeftContext context, IMapper mapper)
        {
            (_context, _mapper) = (context, mapper);
        }
    }
}

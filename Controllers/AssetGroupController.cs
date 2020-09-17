using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KazanNeftApi.DTO;
using KazanNeftApi.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanNeftApi.Controllers
{
    public class AssetGroupController : ApiControllerBase
    {
       
        public AssetGroupController(KazanNeftContext context, IMapper mapper)
            : base(context, mapper) { }
      

        [HttpGet]
        [Route("/assetGroups")]
        public IActionResult GetAssetGroups()
        {
            var groups = _context.AssetGroups.ToList();

            var transferList = _mapper
                .Map<List<AssetGroupDTO>>(groups);

            return new JsonResult(transferList);
        }
    }
}

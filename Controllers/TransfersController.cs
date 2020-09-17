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
    public class TransfersController : ApiControllerBase
    {

        public TransfersController(KazanNeftContext context, IMapper mapper)
            : base(context, mapper) { }

        [HttpGet]
        [Route("/transfers/{assetId}")]
        public IActionResult GetTransfers(long assetId)
        {
            var asset = _context.Assets.Find(assetId);

            var logs = asset.AssetTransferLogs
                .Where(l=>l.TransferDate.AddMonths(12) >= DateTime.Now)
                .ToList();

            var transferList = _mapper.Map<List<AssetTransferLogDTO>>(logs);
            return new JsonResult(transferList);
        }

        [HttpGet]
        [Route("/transfers")]
        public IActionResult GetTransfers()
        {
            var logs = _context.AssetTransferLogs.ToList();
            var transferList = _mapper.Map<List<AssetTransferLogDTO>>(logs);
            return new JsonResult(transferList);
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.DynamicProxy.Generators;
using KazanNeftApi.DTO;
using KazanNeftApi.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanNeftApi.Controllers
{

    public class AssetsController : ApiControllerBase
    {

        public AssetsController(KazanNeftContext context, IMapper mapper)
            : base(context, mapper) { }
       
        /// <summary>
        /// Get all assets from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/assets")]
        public IActionResult GetAssests()
        {
            List<Assets> assets = _context.Assets.ToList();

            List<AssetDTO> transferList
                = _mapper.Map<List<Assets>, List<AssetDTO>>(assets);

            return new JsonResult(transferList);
        }

        /// <summary>
        /// Add asset
        /// </summary>
        /// <param name="assetDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/asset")]
        public IActionResult PostAsset([FromBody] AssetDTO assetDTO)
        {       
            var asset = _mapper.Map<Assets>(assetDTO);
            _context.Attach(asset.AssetGroup);
            _context.Attach(asset.DepartmentLocation);
            _context.Attach(asset.Employee);
            _context.Assets.Add(asset);

            _context.SaveChanges();
            return Content(asset.Id.ToString());
        }

        /// <summary>
        /// Add photo to asset
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="photo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/asset/photo/{assetId}")]
        public async Task<IActionResult> PostPhoto([FromRoute] int assetId)
        {

            int lenght = (int)HttpContext.Request.ContentLength.Value;

            MemoryStream stream = new MemoryStream(lenght);

            await Request.Body.CopyToAsync(stream);

            byte[] photo = stream.ToArray();

            var assetPhoto = new AssetPhotos()
            {
                AssetId = assetId,
                AssetPhoto = photo
            };

            _context.AssetPhotos.Add(assetPhoto);
            _context.SaveChanges();

            return StatusCode(200);
        }

        [HttpGet]
        [Route("/asset/photo/{assetId}")]
        public async Task GetMainPhoto(long assetId)
        {
            Console.WriteLine("Request is got " + assetId);
            var asset = _context.Assets.Find(assetId);

            if(asset.AssetPhotos.Count > 0)
            {
                var bytes = asset.AssetPhotos.ElementAt(0).AssetPhoto;
                HttpContext.Response.ContentLength = bytes.Length;
                await HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
            else
            {
                // HttpContext.Response.ContentLength = 0;
                await HttpContext.Response.WriteAsync("No photo");
            }
        }

        [HttpGet]
        [Route("asset/photos/{assetId}")]
        public IActionResult GetPhotosAmount(long assetId)
        {
            var asset = _context.Assets.Find(assetId);
            return Content(asset.AssetPhotos.Count.ToString());
        }  

        [HttpGet]
        [Route("asset/photo/{assetId}/{photoIndex}")]
        public async Task GetPhoto(long assetId, int photoIndex)
        {
            var asset = _context.Assets.Find(assetId);

            await Response.Body.WriteAsync(asset.AssetPhotos
                .ElementAt(photoIndex).AssetPhoto);
        }

        [HttpPut]
        [Route("asset")]
        public IActionResult PutAsset([FromBody]AssetDTO assetDTO)
        {
            var asset = _mapper.Map<Assets>(assetDTO);

            _context.Attach(asset.DepartmentLocation);
            _context.Attach(asset.Employee);
            _context.Attach(asset.AssetGroup);

            _context.Assets.Update(asset);

            _context.SaveChanges();

            return StatusCode(200);
        }


        /// <summary>
        /// Transfer asset and write transfer logs
        /// </summary>
        /// <param name="assetDTOs">The old and updated assets</param>
        /// <returns></returns>
        [HttpPost]
        [Route("asset/transfer")]
        public IActionResult TransferAsset([FromBody] AssetTransferLogDTO assetTransferDTO)
        {
            var assetTransfer = _mapper.Map<AssetTransferLogs>(assetTransferDTO);
            var updatedAsset = _context.Assets.Find(assetTransfer.AssetId);

            updatedAsset.DepartmentLocation =
                _context.DepartmentLocations.Find(assetTransfer.ToDepartmentLocationId);

            updatedAsset.AssetSn = assetTransfer.ToAssetSn;
            assetTransfer.TransferDate = DateTime.Now;

            _context.Assets.Update(updatedAsset);
            _context.AssetTransferLogs.Add(assetTransfer);

            _context.SaveChanges();

            return StatusCode(200);
            
        }


    }
}

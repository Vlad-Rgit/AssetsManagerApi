using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.DTO
{
    public class AssetTransferLogDTO
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public string FromAssetSN { get; set; }
        public string ToAssetSN { get; set; }
        public long ToDepartmentLocationId { get; set; }
        public long FromDepartmentLocationId { get; set; }
        public DateTime? TransferDate { get; set; }

        public AssetDTO Asset { get; set; }
        public DepartmentLocationDTO FromDepartmentLocation { get; set; }
        public DepartmentLocationDTO ToDepartmentLocation { get; set; }
    }
}

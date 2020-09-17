using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class AssetTransferLogs
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public DateTime TransferDate { get; set; }
        public string FromAssetSn { get; set; }
        public string ToAssetSn { get; set; }
        public long FromDepartmentLocationId { get; set; }
        public long ToDepartmentLocationId { get; set; }

        public virtual Assets Asset { get; set; }
        public virtual DepartmentLocations FromDepartmentLocation { get; set; }
        public virtual DepartmentLocations ToDepartmentLocation { get; set; }
    }
}

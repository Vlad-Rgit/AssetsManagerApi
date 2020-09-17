using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class Assets
    {
        public Assets()
        {
            AssetPhotos = new HashSet<AssetPhotos>();
            AssetTransferLogs = new HashSet<AssetTransferLogs>();
        }

        public long Id { get; set; }
        public string AssetSn { get; set; }
        public string AssetName { get; set; }
        public long DepartmentLocationId { get; set; }
        public long EmployeeId { get; set; }
        public long AssetGroupId { get; set; }
        public string Description { get; set; }
        public DateTime? WarrantyDate { get; set; }

        public virtual AssetGroups AssetGroup { get; set; }
        public virtual DepartmentLocations DepartmentLocation { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<AssetPhotos> AssetPhotos { get; set; }
        public virtual ICollection<AssetTransferLogs> AssetTransferLogs { get; set; }
    }
}

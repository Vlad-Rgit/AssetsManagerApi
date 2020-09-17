using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class DepartmentLocations
    {
        public DepartmentLocations()
        {
            AssetTransferLogsFromDepartmentLocation = new HashSet<AssetTransferLogs>();
            AssetTransferLogsToDepartmentLocation = new HashSet<AssetTransferLogs>();
            Assets = new HashSet<Assets>();
        }

        public long Id { get; set; }
        public long DepartmentId { get; set; }
        public long LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Locations Location { get; set; }
        public virtual ICollection<AssetTransferLogs> AssetTransferLogsFromDepartmentLocation { get; set; }
        public virtual ICollection<AssetTransferLogs> AssetTransferLogsToDepartmentLocation { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
    }
}

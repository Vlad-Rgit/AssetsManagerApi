using KazanNeftApi.Controllers;
using KazanNeftApi.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.DTO
{
    public class AssetDTO
    {
        public long Id { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public EmployeeDTO Employee { get; set; }
        public AssetGroupDTO AssetGroup { get; set; }
        public DepartmentLocationDTO DepartmentLocation { get; set; }
        public DateTime? WarrantyDate { get; set; }
    }
}

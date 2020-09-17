using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class Locations
    {
        public Locations()
        {
            DepartmentLocations = new HashSet<DepartmentLocations>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DepartmentLocations> DepartmentLocations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanNeftApi.DTO
{
    public class DepartmentLocationDTO
    {
        public long Id { get; set; }
        public DepartmentDTO Department { get; set; }
        public LocationDTO Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

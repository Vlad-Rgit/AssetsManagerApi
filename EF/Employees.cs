using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class Employees
    {
        public Employees()
        {
            Assets = new HashSet<Assets>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Assets> Assets { get; set; }
    }
}

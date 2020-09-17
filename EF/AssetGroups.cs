using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class AssetGroups
    {
        public AssetGroups()
        {
            Assets = new HashSet<Assets>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Assets> Assets { get; set; }
    }
}

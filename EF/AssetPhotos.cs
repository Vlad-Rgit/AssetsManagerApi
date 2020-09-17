using System;
using System.Collections.Generic;

namespace KazanNeftApi.EF
{
    public partial class AssetPhotos
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public byte[] AssetPhoto { get; set; }

        public virtual Assets Asset { get; set; }
    }
}

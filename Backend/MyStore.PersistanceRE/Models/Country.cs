using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class Country
    {
        public Country()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Isocode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Culture { get; set; } = null!;

        public virtual ICollection<Store> Stores { get; set; }
    }
}

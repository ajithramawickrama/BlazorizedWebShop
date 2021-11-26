using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int CountryId { get; set; }
        public string StoreName { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
        public ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public string StoreName { get; set; }
        public Country Country { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

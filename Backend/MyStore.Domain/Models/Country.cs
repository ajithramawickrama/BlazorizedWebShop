using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string ISOCode { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public ICollection<Store> Stores { get; set; } 
    }
}

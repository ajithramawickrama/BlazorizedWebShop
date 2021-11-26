using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public string StoreName { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace MyStore.PersistanceRE.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Gender { get; set; }
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public string Country { get; set; } = null!;
        public DateTime LastPurchaseDate { get; set; }
    }
}

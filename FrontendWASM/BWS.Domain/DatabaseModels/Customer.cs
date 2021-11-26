﻿

namespace BWS.Domain.DatabaseModels;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string Title { get; set; }
    public string? Gender { get; set; }
    //public string Email { get; set; }
    public string MobileNumber { get; set; }
    //public string Address1 { get; set; }
    //public string? Address2 { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    //public string? StateProvince { get; set; }
    //public string Country { get; set; }

}

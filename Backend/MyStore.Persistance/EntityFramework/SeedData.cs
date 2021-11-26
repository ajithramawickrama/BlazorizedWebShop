using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Persistance.EntityFramework
{
    internal static class SeedData
    {
        internal static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    ISOCode = "USA",
                    Name = "United States",
                    Culture = "en-US"
                },
                new Country
                {
                    Id = 2,
                    ISOCode = "CAN",
                    Name = "Canada",
                    Culture = "en-CA"
                },
                new Country
                {
                    Id = 3,
                    ISOCode = "GBR",
                    Name = "United Kingdom",
                    Culture = "en-GB"
                },
                new Country
                {
                    Id = 4,
                    ISOCode = "DEU",
                    Name = "Germany",
                    Culture = "de-DE"
                },
                new Country
                {
                    Id = 5,
                    ISOCode = "NOR",
                    Name = "Norway",
                    Culture = "no-NO"
                },
                new Country
                {
                    Id = 6,
                    ISOCode = "SGP",
                    Name = "Singapore",
                    Culture = "en-SG"
                },
                new Country
                {
                    Id = 7,
                    ISOCode = "AUS",
                    Name = "Australia",
                    Culture = "en-AU"
                }
                );
        }

        internal static void SeedStores(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id=1,
                    CountryId=1,
                    Code="USA1",
                    StoreName="New York",
                },
                new Store
                {
                    Id=2,
                    CountryId = 1,
                    Code = "USA2",
                    StoreName = "Los Angeles",
                },
                new Store
                {
                    Id=3,
                    CountryId = 2,
                    Code = "CAN1",
                    StoreName = "Toronto Store",
                },
                new Store
                {
                    Id=4,
                    CountryId = 2,
                    Code = "CAN2",
                    StoreName = "Vancour Store",
                },
                new Store
                {
                    Id=5,
                    CountryId = 3,
                    Code = "UK1",
                    StoreName = "London Store",
                },
                new Store
                {
                    Id=6,
                    CountryId = 4,
                    Code = "GER1",
                    StoreName = "Munich Store",
                },
                new Store
                {
                    Id=7,
                    CountryId = 5,
                    Code = "NOW1",
                    StoreName = "Oslo Store",
                },
                new Store
                {
                    Id=8,
                    CountryId = 6,
                    Code = "SIN1",
                    StoreName = "Singapore Store",
                },
                new Store
                {
                    Id=9,
                    CountryId = 7,
                    Code = "AUS1",
                    StoreName = "Sedney Store",
                }

                );
        }
    }
}

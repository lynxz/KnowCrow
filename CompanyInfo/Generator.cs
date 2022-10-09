using KnowCrow.CompanyInfo.Data;

namespace KnowCrow.CompanyInfo
{
    internal static class Generator
    {
        public static IDictionary<int, Company> CompanyData()
        {
            var companies = new Dictionary<int, Company>
            {
                { 1, new Company
                    {
                        Id = 1,
                        Name = "Ericsson",
                        Description = "Telecommunications company",
                        Address = new Address { Id = 1, Country = "Sweden", City = "Stockholm", Phone = "+4676555555", PostalCode = 16440, Street = "Torshamnsgatan 21" },
                        Contact = new Person { Id = 1, FirstName = "John", LastName = "Doe", Phone = "+4676555555", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 2, new Company
                    {
                        Id = 2,
                        Name = "Finisar",
                        Description = "Fiberoptic Laser Manufacturer",
                        Address = new Address { Id = 2, Country = "Sweden", City = "Stockholm", Phone = "+4676555555", PostalCode = 17543, Street = "Bruttovägen 7" },
                        Contact = new Person { Id = 2, FirstName = "Thomas", LastName = "Andersson", Phone = "+4676555555", Title = TitleType.Doctor },
                        Active = true
                    }
                },
                { 3, new Company
                    {
                        Id = 3,
                        Name = "Ambea",
                        Description = "Care provider",
                        Address = new Address { Id = 3, Country = "Sweden", City = "Stockholm", Phone = "+4676555555", PostalCode = 16956, Street = "Evenemangsgatan 21" },
                        Contact = new Person { Id = 3, FirstName = "Karin", LastName = "Terror", Phone = "+4676555555", Title = TitleType.Mrs },
                        Active = true
                    }
                },
                { 4, new Company
                    {
                        Id = 4,
                        Name = "GSR",
                        Description = "Insurance fraud detection",
                        Address = new Address { Id = 4, Country = "Sweden", City = "Stockholm", Phone = "+46852278490", PostalCode = 10452, Street = "Karlavägen 108" },
                        Contact = new Person { Id = 4, FirstName = "Boss", LastName = "Hugo", Phone = "+4676555555", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 5, new Company
                    {
                        Id = 5,
                        Name = "Bergman & Beving",
                        Description = "Real Estate Construction",
                        Address = new Address { Id = 5, Country = "Sweden", City = "Stockholm", Phone = "+46104547700", PostalCode = 10452, Street = "Cardellgatan 1" },
                        Contact = new Person { Id = 5, FirstName = "Beving", LastName = "Bergman", Phone = "+4676555555", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 6, new Company
                    {
                        Id = 6,
                        Name = "AFF",
                        Description = "Real Estate Contract Provider",
                        Address = new Address { Id = 6, Country = "Sweden", City = "Stockholm", Phone = "+46868442600", PostalCode = 11151, Street = "Drottningsgatan 33" },
                        Contact = new Person { Id = 6, FirstName = "Phillip", LastName = "Någonting", Phone = "+4676555555", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 7, new Company
                    {
                        Id = 7,
                        Name = "UniLabs",
                        Description = "Test Laboratory",
                        Address = new Address { Id = 7, Country = "Sweden", City = "Uppsala", Phone = "+46771407720", PostalCode = 75320, Street = "Dragarbrunnsgatan 72 B" },
                        Contact = new Person { Id = 7, FirstName = "Jane", LastName = "Doe", Phone = "+4676555555", Title = TitleType.Miss },
                        Active = true
                    }
                },
                { 8, new Company
                    {
                        Id = 8,
                        Name = "Telia",
                        Description = "Tele Provider",
                        Address = new Address { Id = 8, Country = "Sweden", City = "Stockholm", Phone = "+46850455000", PostalCode = 16979, Street = "Stjärntorget 1" },
                        Contact = new Person { Id = 8, FirstName = "Pontus", LastName = "Pilatius", Phone = "+4676555555", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 9, new Company
                    {
                        Id = 9,
                        Name = "BossMedia",
                        Description = "Media Company",
                        Address = new Address { Id = 9, Country = "Sweden", City = "Växjö", Phone = "N/A", PostalCode = 0, Street = "N/A" },
                        Contact = new Person { Id = 12, FirstName = "", LastName = "", Phone = "N/A", Title = TitleType.None },
                        Active = false
                    }
                },
                { 10, new Company
                    {
                        Id = 10,
                        Name = "Chas Visual Management",
                        Description = "IT Consultancy",
                        Address = new Address { Id = 10, Country = "Sweden", City = "Stockholm", Phone = "+46087445549", PostalCode = 13141, Street = "Stubbsundsvägen 11" },
                        Contact = new Person { Id = 10, FirstName = "Oliver", LastName = "Wirhed", Phone = "+460735201238", Title = TitleType.Mr },
                        Active = true
                    }
                },
                { 11, new Company
                    {
                        Id = 11,
                        Name = "Energirådgivningen",
                        Description = "Energy Efficiency",
                        Address = new Address { Id = 11, Country = "Sweden", City = "Stockholm", Phone = "+46855559000", PostalCode = 18380, Street = "Esplanaden 3" },
                        Contact = new Person { Id = 11, FirstName = "Tobbe", LastName = "Trollkarl", Phone = "+46073555555", Title = TitleType.None },
                        Active = true
                    }
                },
                { 12, new Company
                    {
                        Id = 12,
                        Name = "Upsys",
                        Description = "Cloud",
                        Address = new Address { Id = 12, Country = "Sweden", City = "Uppsala", Phone = "N/A", PostalCode = 75321, Street = "Kungsgatan 47A" },
                        Contact = new Person { Id = 12, FirstName = "", LastName = "", Phone = "N/A", Title = TitleType.None },
                        Active = false
                    }
                }
            };
            return companies;
        }
    }
}

namespace KnowCrow.CompanyInfo.Data
{
    public class Company
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Address? Address { get; set; }

        public Person? Contact { get; set; }

        public bool Active { get; set; }
    }
}

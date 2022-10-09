namespace KnowCrow.CompanyInfo.Data
{
    public enum TitleType
    {
        None = 0,
        Mr = 1,
        Miss = 2,
        Mrs = 3,
        Doctor = 4
    }

    public class Person
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public TitleType Title { get; set; }

        public string? Phone { get; set; }
    }
}

namespace KnowCrow.GraphQL.Data;

public class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description {get;set;}

    public ICollection<Score> Scores { get; set; } = new List<Score>();

    public ICollection<WorkExperience> Experiences {get;set;} = new List<WorkExperience>();
}

namespace KnowCrow.GraphQL.Data;

public class WorkExperience
{
    public int Id { get; set; }

    public DateTime Started { get; set; }

    public DateTime? Ended { get; set; }

    public string? Description { get; set; }

    public Person? Person { get; set; }

    public ICollection<Role>? Roles { get; set; }

    public Company? Company { get; set; }

    public ICollection<Subject>? Subjects { get; set; }
}
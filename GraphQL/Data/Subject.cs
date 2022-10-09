namespace KnowCrow.GraphQL.Data;

public class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Person?>? People { get; set; }
}

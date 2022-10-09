namespace KnowCrow.GraphQL.Data;

public class Score
{
    public int Id { get; set; }

    public int Value { get; set; }

    public Person? Person { get; set; }

    public Subject? Subject { get; set; }
}
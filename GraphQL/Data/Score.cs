namespace KnowCrow.GraphQL.Data;

/// <summary>
/// Skill level of an individual in a specific subject.
/// </summary>
public class Score
{
    /// <summary>
    /// Database ID.
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Persons skill in this subject, rates between 1 and 11.
    /// </summary>
    /// <value></value>
    public int Value { get; set; }

    /// <summary>
    /// Person who has skill in this subject.
    /// </summary>
    /// <value></value>
    public Person? Person { get; set; }

    /// <summary>
    /// Subject which is rated.
    /// </summary>
    /// <value></value>
    public Subject? Subject { get; set; }
}
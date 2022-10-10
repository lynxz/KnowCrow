namespace KnowCrow.GraphQL.Data;

/// <summary>
/// Framework, technique, or skill.
/// </summary>
public class Subject
{
    /// <summary>
    /// Database ID.
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Name of subject.
    /// </summary>
    /// <value></value>
    public string? Name { get; set; }

    /// <summary>
    /// Description of subject.
    /// </summary>
    /// <value></value>
    public string? Description { get; set; }

    /// <summary>
    /// Relevant people.
    /// </summary>
    /// <value></value>
    public ICollection<Person?>? People { get; set; }
}

namespace KnowCrow.GraphQL.Data;

/// <summary>
/// Work experience at a company
/// </summary>
public class WorkExperience
{
    /// <summary>
    /// Database ID
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Start date for an assignment
    /// </summary>
    /// <value></value>
    public DateTime Started { get; set; }

    /// <summary>
    /// Date when assignment is finished
    /// </summary>
    /// <value></value>
    public DateTime? Ended { get; set; }

    /// <summary>
    /// Description of work assignment
    /// </summary>
    /// <value></value>
    public string? Description { get; set; }

    /// <summary>
    /// Person who this work experience relates to.
    /// </summary>
    /// <value></value>
    public Person? Person { get; set; }

    /// <summary>
    /// Roles of the person during the work assignment
    /// </summary>
    /// <value></value>
    public ICollection<Role>? Roles { get; set; }

    /// <summary>
    /// Company the assignment was performed at.
    /// </summary>
    /// <value></value>
    public Company? Company { get; set; }

    /// <summary>
    /// Relevant skills, frameworks, and techniques that
    /// was utilized during the assignment.
    /// </summary>
    /// <value></value>
    public ICollection<Subject>? Subjects { get; set; }
}
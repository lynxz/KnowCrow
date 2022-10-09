namespace KnowCrow.GraphQL.Data;

/// <summary>
/// Person with a life story.
/// </summary>
public class Person
{
    /// <summary>
    /// Database ID of Person
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Name of the person
    /// </summary>
    /// <value></value>
    public string? Name { get; set; }

    /// <summary>
    /// Description of person, who they are and how
    /// they generally behave.
    /// </summary>
    /// <value></value>
    public string? Description {get;set;}

    /// <summary>
    /// Different skills the person has acquired
    /// and how they rate themselves at these skills.
    /// </summary>
    /// <typeparam name="Score"></typeparam>
    /// <returns></returns>
    public ICollection<Score> Scores { get; set; } = new List<Score>();

    /// <summary>
    /// The persons work experience.
    /// </summary>
    /// <typeparam name="WorkExperience"></typeparam>
    /// <returns></returns>
    public ICollection<WorkExperience> Experiences {get;set;} = new List<WorkExperience>();
}

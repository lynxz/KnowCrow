namespace KnowCrow.GraphQL.Data;

/// <summary>
/// Company information.
/// </summary>
public class Company
{
    /// <summary>
    /// Database ID.
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Remote company information ID.
    /// </summary>
    /// <value></value>
    public int CompanyInformationId { get; set; }

    /// <summary>
    /// Name of company.
    /// </summary>
    /// <value></value>
    public string? Name { get; set; }
}
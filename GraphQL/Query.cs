using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL;

public class Query
{
    /// <summary>
    /// Fetching working roles.
    /// </summary>
    /// <param name="context">Database context.</param>
    /// <returns>All working roles in system</returns>
    public IQueryable<Role> GetRoles(CrowDbContext context) =>
        context.Roles;

    /// <summary>
    /// Fetching companies.
    /// </summary>
    /// <param name="context">Database context.</param>
    /// <returns>All companies in system</returns>
    public IQueryable<Company> GetCompanies(CrowDbContext context) =>
        context.Companies;

    /// <summary>
    /// Fetching detail company information from remote REST service.
    /// </summary>
    /// <param name="service">Service client for REST endpoint.</param>
    /// <param name="cancellationToken">Token for interrupting request.</param>
    /// <returns>Detailed information for companies at remote endpoint.</returns>
    public Task<ICollection<Clients.Company>> GetCompaniesInformationAsync(
        [Service] Clients.CompanyInfoService service,
        CancellationToken cancellationToken) =>
        service.CompaniesAllAsync(cancellationToken);
}
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL;

public class Query
{
    public IQueryable<Role> GetRoles(CrowDbContext context) =>
        context.Roles;

    public IQueryable<Company> GetCompanies(CrowDbContext context) =>
        context.Companies;

    public Task<ICollection<Clients.Company>> GetCompaniesInformationAsync(
        [Service] Clients.CompanyInfoService service,
        CancellationToken cancellationToken) =>
        service.CompaniesAllAsync(cancellationToken);
}
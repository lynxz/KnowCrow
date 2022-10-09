using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;

namespace KnowCrow.GraphQL;

public class Query
{
    public IQueryable<Role> GetRoles(CrowDbContext context) =>
        context.Roles;

    public IQueryable<Company> GetCompanies(CrowDbContext context) =>
        context.Companies;
}
using HotChocolate.AspNetCore.Authorization;
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL;

[Authorize(Roles = new[] { "Admin" })]
public class Mutation
{
    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Company> AddCompanyAsync(
        string name,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter {nameof(name)} cannot be null nor an empty string");

        var company = new Company
        {
            Name = name
        };

        context.Companies.Add(company);
        await context.SaveChangesAsync(cancellationToken);

        return company;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Company> RemoveCompanyAsync(
        int id,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var company = await context.Companies.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        if (company is null)
            throw new ArgumentException($"Could not find a matching company for id {id}");

        context.Companies.Remove(company);
        await context.SaveChangesAsync(cancellationToken);

        return company;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Role> AddRoleAsync(
        string name,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter {nameof(name)} cannot be null nor an empty string");

        var role = new Role
        {
            Name = name
        };

        context.Roles.Add(role);
        await context.SaveChangesAsync(cancellationToken);

        return role;
    }
}
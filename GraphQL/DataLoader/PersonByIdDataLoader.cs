using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.DataLoader;

public class PersonByIdDataLoader : BatchDataLoader<int, Person>
{
    private readonly IDbContextFactory<CrowDbContext> _contextFactory;

    public PersonByIdDataLoader(
        IDbContextFactory<CrowDbContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory;
    }

    protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        return await dbContext.People
            .Where(s => keys.Contains(s.Id))
            .Include(s => s.Experiences)
                .ThenInclude(s => s.Subjects)
            .Include(s => s.Experiences)
                .ThenInclude(s => s.Roles)
            .Include(s => s.Experiences)
                .ThenInclude(s => s.Company)
            .Include(s => s.Scores)
                .ThenInclude(s => s.Subject)
            .ToDictionaryAsync(s => s.Id, cancellationToken);
    }
}
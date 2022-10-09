using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.DataLoader;

public class SubjectByIdDataLoader : BatchDataLoader<int, Subject>
{
    private readonly IDbContextFactory<CrowDbContext> _contextFactory;

    public SubjectByIdDataLoader(
        IDbContextFactory<CrowDbContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Subject>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        await using var dbContext = _contextFactory.CreateDbContext();

        return await dbContext.Subjects
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, cancellationToken);
    }
}
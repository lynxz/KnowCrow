using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.DataLoader;

public class ScoreByIdDataLoader : BatchDataLoader<int, Score>
{
    private readonly IDbContextFactory<CrowDbContext> _contextFactory;

    public ScoreByIdDataLoader(
        IDbContextFactory<CrowDbContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Score>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        await using var dbContext = _contextFactory.CreateDbContext();

        return await dbContext.Scores
            .Include(s => s.Person)
            .Include(s => s.Subject)
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, cancellationToken);
    }
}

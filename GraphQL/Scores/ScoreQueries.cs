using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Scores;

[ExtendObjectType("Query")]
public class ScoreQueries
{
    [UsePaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering(typeof(ScoreFilterType))]
    [UseSorting]
    public IQueryable<Score> GetScores(CrowDbContext context) =>
        context.Scores;

    [UseSingleOrDefault]
    [UseProjection]
    public IQueryable<Score> GetScoreById(
        [ID(nameof(Score))] int id,
        CrowDbContext dbContext) =>
        dbContext.Scores.Where(s => s.Id == id);
}
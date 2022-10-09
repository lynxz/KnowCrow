using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Scores;

[ExtendObjectType("Query")]
public class ScoreQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering(typeof(ScoreFilterType))]
    [UseSorting]
    public IQueryable<Score> GetScores(CrowDbContext context) =>
        context.Scores;
}
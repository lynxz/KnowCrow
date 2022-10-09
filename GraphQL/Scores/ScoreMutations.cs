using HotChocolate.AspNetCore.Authorization;
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Scores;

[Authorize(Roles = new [] {"Admin"})]
[ExtendObjectType("Mutation")]
public class ScoreMutations
{
    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Score> AddScoreAsync(
        int value,
        [ID(nameof(Person))] int personId,
        int subjectId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (value < 1 || value > 11)
            throw new ArgumentException($"Parameter {nameof(value)} must be between 1 and 11.");

        var person = await context.People.FindAsync(new object[] { personId }, cancellationToken: cancellationToken);
        var subject = await context.Subjects.FindAsync(new object[] { subjectId }, cancellationToken: cancellationToken);

        var score = new Score
        {
            Value = value,
            Subject = subject,
            Person = person
        };

        context.Scores.Add(score);
        await context.SaveChangesAsync(cancellationToken);

        return score;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Score> UpdateScoreAsync(
            [ID(nameof(Score))] int scoreId,
            int value,
            [ScopedService] CrowDbContext context,
            CancellationToken cancellationToken)
    {
        if (value < 1 || value > 11)
            throw new ArgumentException($"Parameter {nameof(value)} must be between 1 and 11.");

        var score = await context.Scores.FindAsync(new object[] { scoreId }, cancellationToken: cancellationToken);
        if (score is null)
            throw new ArgumentException($"Could not find a matching person for id {scoreId}");

        score.Value = value;
        await context.SaveChangesAsync(cancellationToken);

        return score;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Score> RemoveScoreAsync(
        [ID(nameof(Score))] int scoreId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var score = await context.Scores.FindAsync(new object[] { scoreId }, cancellationToken: cancellationToken);
        if (score is null)
            throw new ArgumentException($"Could not find a matching person for id {scoreId}");

        context.Remove(score);
        await context.SaveChangesAsync(cancellationToken);

        return score;
    }
}
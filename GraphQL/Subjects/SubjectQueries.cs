using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.Subjects;

[ExtendObjectType("Query")]
public class SubjectQueries
{
    [UsePaging(MaxPageSize = 100)]
    [UseSorting]
    public IQueryable<Subject> GetSubjects(CrowDbContext context) =>
        context.Subjects;

    public Task<Subject> GetSubjectByIdAsync(
        [ID(nameof(Subject))] int id,
        SubjectByIdDataLoader subjectById,
        CancellationToken cancellationToken) =>
        subjectById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Subject>> GetSubjectByIdsAsync(
        [ID(nameof(Subject))] int[] ids,
        SubjectByIdDataLoader subjectById,
        CancellationToken cancellationToken) =>
        await subjectById.LoadAsync(ids, cancellationToken);

    public async Task<IEnumerable<Subject>> GetSubjectByNameAsync(
        string name,
        CrowDbContext context,
        CancellationToken cancellationToken) =>
        await context.Subjects
            .Where(s => s.Name != null && s.Name.StartsWith(name))
            .ToListAsync(cancellationToken);
}

using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.Subjects;

[Node]
[ExtendObjectType(typeof(Subject))]
public class SubjectNode
{
    [NodeResolver]
    public static async Task<Subject?> GetSubjectById(
        int id,
        CrowDbContext context,
        CancellationToken cancellationToken) =>
        await context.Subjects.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
}
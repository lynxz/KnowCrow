using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.People;

[ExtendObjectType("Query")]
public class PersonQueries
{
    [UseProjection]
    public IQueryable<Person> GetPeople(CrowDbContext context) =>
        context.People;

    public Task<Person> GetPersonByIdAsync(
        [ID(nameof(Person))] int id,
        PersonByIdDataLoader personById,
        CancellationToken cancellationToken) =>
        personById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Person>> GetPersonByIdsAsync(
        [ID(nameof(Person))] int[] ids,
        PersonByIdDataLoader personById,
        CancellationToken cancellationToken) =>
        await personById.LoadAsync(ids, cancellationToken);
}
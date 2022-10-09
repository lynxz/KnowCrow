using HotChocolate.AspNetCore.Authorization;
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.People;

[Authorize(Roles = new [] {"Admin"})]
[ExtendObjectType("Mutation")]
public class PersonMutations
{
    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Person> AddPersonAsync(
        string name,
        string? description,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter {nameof(name)} cannot be null nor an empty string");

        var person = new Person
        {
            Name = name,
            Description = description
        };

        context.People.Add(person);
        await context.SaveChangesAsync(cancellationToken);

        return person;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Person> UpdateDescriptionAsync(
        [ID(nameof(Person))]  int personId,
        string? description,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var person = await context.People.FindAsync(new object[] { personId }, cancellationToken: cancellationToken);
        if (person is null)
            throw new ArgumentException($"Could not find a matching person for id {personId}");

        person.Description = description;
        await context.SaveChangesAsync(cancellationToken);

        return person;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Person> UpdateNameAsync(
        [ID(nameof(Person))]  int personId,
        string name,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter {nameof(name)} cannot be null nor an empty string");

        var person = await context.People.FindAsync(new object[] { personId }, cancellationToken: cancellationToken);
        if (person is null)
            throw new ArgumentException($"Could not find a matching person for id {personId}");

        person.Name = name;
        await context.SaveChangesAsync(cancellationToken);

        return person;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Person> RemovePersonAsync(
        [ID(nameof(Person))] int personId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var person = await context.People.FindAsync(new object[] { personId }, cancellationToken: cancellationToken);
        if (person is null)
            throw new ArgumentException($"Could not find a matching person for id {personId}");

        using var scope = context.Database.BeginTransaction();
        context.People.Remove(person);
        context.Experiences.RemoveRange(person.Experiences);
        context.Scores.RemoveRange(person.Scores);

        await context.SaveChangesAsync(cancellationToken);
        await scope.CommitAsync(cancellationToken);

        return person;
    }
}
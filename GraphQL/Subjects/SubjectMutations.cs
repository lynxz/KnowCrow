using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Subjects;

[Authorize(Roles = new[] { "Admin" })]
[ExtendObjectType("Mutation")]
public class SubjectMutations
{
    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Subject> AddSubjectAsync(
        string name,
        string? description,
        [Service] ITopicEventSender sender,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException($"Parameter {nameof(name)} cannot be null nor an empty string");

        var subject = new Subject
        {
            Name = name,
            Description = description
        };

        context.Subjects.Add(subject);
        await context.SaveChangesAsync(cancellationToken);

        await sender.SendAsync(nameof(SubjectSubscriptions.SubjectAdded), subject, cancellationToken);

        return subject;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<Subject> RemoveSubjectAsync(
        [ID(nameof(Subject))] int id,
        [Service] ITopicEventSender sender,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var subject = await context.Subjects.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        if (subject is null)
            throw new ArgumentException($"Could not find a matching Subject for id {id}");

        context.Subjects.Remove(subject);
        await context.SaveChangesAsync(cancellationToken);

        await sender.SendAsync("SubjectDeletion", subject, cancellationToken);

        return subject;
    }
}
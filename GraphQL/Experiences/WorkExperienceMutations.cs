using HotChocolate.AspNetCore.Authorization;
using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.Experiences;

[Authorize(Roles = new [] {"Admin"})]
[ExtendObjectType("Mutation")]
public class WorkExperienceMutations
{
    [UseMutationConvention]
    public async Task<WorkExperience> AddWorkExperienceAsync(
        [ID(nameof(Person))] int personId,
        int companyId,
        string? description,
        DateTime started,
        DateTime? ended,
        List<int>? roleIds,
        [ID(nameof(Subject))] List<int>? subjectIds,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var person = await context.People.FindAsync(new object[] { personId }, cancellationToken: cancellationToken);
        var company = await context.Companies.FindAsync(new object[] { companyId }, cancellationToken);

        subjectIds ??= new List<int>();
        var subjects = await context.Subjects.Where(s => subjectIds.Contains(s.Id)).ToListAsync(cancellationToken);

        roleIds ??= new List<int>();
        var roles = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync(cancellationToken);

        var workExperience = new WorkExperience
        {
            Person = person,
            Company = company,
            Description = description,
            Roles = roles,
            Subjects = subjects,
            Started = started,
            Ended = ended
        };

        context.Experiences.Add(workExperience);
        await context.SaveChangesAsync(cancellationToken);

        return workExperience;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<WorkExperience> UpdateWorkExperienceDescription(
        int experienceId,
        string description,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var experience = await context.Experiences.FindAsync(new object?[] { experienceId }, cancellationToken: cancellationToken);
        if (experience is null)
            throw new ArgumentException($"Could not find matching WorkExperience for ID {experienceId}.");

        experience.Description = description;
        await context.SaveChangesAsync(cancellationToken);

        return experience;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<WorkExperience> AddSubjectToWorkExperience(
        int experienceId,
        [ID(nameof(Subject))] int subjectId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var experience = await context.Experiences.Include(e => e.Subjects).FirstOrDefaultAsync(e => e.Id == experienceId, cancellationToken);
        if (experience is null)
            throw new ArgumentException($"Could not find matching WorkExperience for ID {experienceId}.");

        var subject = await context.Subjects.FindAsync(new object?[] { subjectId }, cancellationToken: cancellationToken);
        if (subject is null)
            throw new ArgumentException($"Could not find matching Subject for ID {subjectId}.");

        experience.Subjects ??= new List<Subject>();
        if (!experience.Subjects.Contains(subject))
            experience.Subjects.Add(subject);

        await context.SaveChangesAsync(cancellationToken);

        return experience;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<WorkExperience> RemoveSubjectFromWorkExperience(
        int experienceId,
        [ID(nameof(Subject))] int subjectId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var experience = await context.Experiences.Include(e => e.Subjects).FirstOrDefaultAsync(e => e.Id == experienceId, cancellationToken);
        if (experience is null)
            throw new ArgumentException($"Could not find matching WorkExperience for ID {experienceId}.");

        var subject = await context.Subjects.FindAsync(new object?[] { subjectId }, cancellationToken: cancellationToken);
        if (subject is null)
            throw new ArgumentException($"Could not find matching Subject for ID {subjectId}.");

        experience.Subjects ??= new List<Subject>();
        if (experience.Subjects.Contains(subject))
            experience.Subjects.Remove(subject);

        await context.SaveChangesAsync(cancellationToken);

        return experience;
    }

    [UseMutationConvention]
    [Error(typeof(ArgumentException))]
    public async Task<WorkExperience> RemoveWorkExperienceAsync(
        int experienceId,
        [ScopedService] CrowDbContext context,
        CancellationToken cancellationToken)
    {
        var experience = await context.Experiences.FindAsync(new object?[] { experienceId }, cancellationToken: cancellationToken);
        if (experience is null)
            throw new ArgumentException($"Could not find matching WorkExperience for ID {experienceId}.");

        context.Experiences.Remove(experience);
        await context.SaveChangesAsync(cancellationToken);

        return experience;
    }
}
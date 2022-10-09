using KnowCrow.GraphQL.Configuration;
using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;
using KnowCrow.GraphQL.Experiences;
using KnowCrow.GraphQL.People;
using KnowCrow.GraphQL.Scores;
using KnowCrow.GraphQL.Security;
using KnowCrow.GraphQL.Subjects;
using KnowCrow.GraphQL.Types;
using Microsoft.AspNetCore.Authentication;

namespace KnowCrow.GraphQL;

public static class Extensions
{
    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder, IConfiguration configuration)
    {
        var keyRoles = configuration.GetSection("Keys").Get<KeyRoleConfiguration[]>();
        builder.AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(ApiKeyDefaults.SchemeName, opt => opt.KeyRoles.AddRange(keyRoles));
        return builder;
    }

    public static IServiceCollection AddGraphQLService(this IServiceCollection services)
    {
        services.AddGraphQLServer()
        .AddAuthorization()
        .AddGlobalObjectIdentification()
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .AddQueryType<Query>()
            .AddTypeExtension<PersonQueries>()
            .AddTypeExtension<ScoreQueries>()
            .AddTypeExtension<SubjectQueries>()
        .AddMutationType<Mutation>()
            .AddTypeExtension<PersonMutations>()
            .AddTypeExtension<ScoreMutations>()
            .AddTypeExtension<WorkExperienceMutations>()
            .AddTypeExtension<SubjectMutations>()
        .AddSubscriptionType(d => d.Name("Subscription"))
            .AddTypeExtension<SubjectSubscriptions>()
        .AddType<PersonType>()
        .AddType<ScoreType>()
        .AddType<CompanyType>()
        .AddTypeExtension<SubjectNode>()
        .AddMutationConventions()
        .AddDataLoader<SubjectByIdDataLoader>()
        .AddDataLoader<ScoreByIdDataLoader>()
        .RegisterDbContext<CrowDbContext>(kind: DbContextKind.Pooled);

        services.AddInMemorySubscriptions();

        return services;
    }
}
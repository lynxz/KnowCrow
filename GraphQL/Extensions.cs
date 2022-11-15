using HotChocolate.Execution.Configuration;
using KnowCrow.GraphQL.Configuration;
using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.DataLoader;
using KnowCrow.GraphQL.Diagnostics;
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
        .AddMutationConventions()
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .UseMyPipeLine()
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
        .AddDataLoader<SubjectByIdDataLoader>()
        .AddDataLoader<ScoreByIdDataLoader>()
        .PublishSchemaDefinition(c =>
        {
            c.SetName("knowcrow");
        })
        .RegisterDbContext<CrowDbContext>(kind: DbContextKind.Pooled);

        services.AddInMemorySubscriptions();

        return services;
    }

    public static IRequestExecutorBuilder UseMyPipeLine(this IRequestExecutorBuilder requestBuilder) =>
        requestBuilder
            .UseInstrumentations()
            .UseExceptions()
            .UseTimeout()
            .UseDocumentCache()
            .UseDocumentParser()
            .UseDocumentValidation()
            .UseOperationCache()
            .UseOperationComplexityAnalyzer()
            .UseOperationResolver()
            .UseOperationVariableCoercion()
            .UseRequest(next => async context =>
            {
                Console.WriteLine($"before next: {context.Document}");
                try
                {
                    await next(context);
                }
                catch (GraphQLException ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                Console.WriteLine($"after next: {context.Result}");
            })
            .UseOperationExecution();

    public static IRequestExecutorBuilder AddDiagnostics(this IRequestExecutorBuilder requestBuilder) =>
        requestBuilder
        .AddDiagnosticEventListener<HttpRequestPerformanceEventListener>()
        .AddDiagnosticEventListener<ExceptionPrinterExecutionEventListener>();

    public static IObjectFieldDescriptor UseToUpper(this IObjectFieldDescriptor descriptor) =>
        descriptor.Use(next => async context =>
        {
            await next(context);

            if (context.Result is string s)
                context.Result = s.ToUpperInvariant();
        });
}
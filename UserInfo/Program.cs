using KnowCrow.UserInfo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserInfoService>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .PublishSchemaDefinition(c => c
        .SetName("accounts")
        .IgnoreRootTypes()
        .AddTypeExtensionsFromFile("./Stitching.graphql"));

var app = builder.Build();

app.MapGraphQL();

app.Run();

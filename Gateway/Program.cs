var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("accounts", c => c.BaseAddress = new Uri("http://localhost:5000/graphql"));
builder.Services.AddHttpClient("knowcrow", c => c.BaseAddress = new Uri("http://localhost:5243/graphql"));

builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema("knowcrow")
    .AddRemoteSchema("accounts");

var app = builder.Build();

app.MapGraphQL();

app.Run();

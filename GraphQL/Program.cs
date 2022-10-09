using KnowCrow.GraphQL;
using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<CrowDbContext>(options => options.UseSqlite("Data Source=knowcrow.db"));

builder.Services.AddGraphQLService();

builder.Services.AddAuthentication(ApiKeyDefaults.SchemeName)
    .AddApiKey(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

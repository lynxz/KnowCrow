using KnowCrow.GraphQL;
using KnowCrow.GraphQL.Clients;
using KnowCrow.GraphQL.Data;
using KnowCrow.GraphQL.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<CrowDbContext>(options => options.UseSqlite("Data Source=knowcrow.db"));

builder.Services.AddHttpClient("accounts", c => c.BaseAddress = new Uri("http://localhost:5000/graphql"));
builder.Services.AddHttpClient<CompanyInfoService>();

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

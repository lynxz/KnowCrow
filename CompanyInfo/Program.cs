using KnowCrow.CompanyInfo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICompanyService, CompanyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/companies", (ICompanyService service) => service.GetCompanies());
app.MapGet("/api/companies/{id:int}", (int id, ICompanyService service) => service.GetCompany(id));

app.Run();

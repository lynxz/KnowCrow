using Microsoft.EntityFrameworkCore;

namespace KnowCrow.GraphQL.Data;

public class CrowDbContext : DbContext
{
    public CrowDbContext(DbContextOptions<CrowDbContext> options) : base(options)
    {
    }

    public DbSet<Subject> Subjects => Set<Subject>();

    public DbSet<Person> People => Set<Person>();

    public DbSet<Score> Scores => Set<Score>();

    public DbSet<WorkExperience> Experiences => Set<WorkExperience>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Role> Roles => Set<Role>();
}
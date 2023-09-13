using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Infra.Data.EntityConfigurations;

namespace School.Infra.Data.Context;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    { }

    //public DbSet<Professor> Professors => Set<Professor>();
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Somente adicionar quando for a conexão do banco de dados real
        //modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
    }

    //public SchoolDbContext()
    //{
    //    Professors = new List<Professor>();
    //}
    //public List<Professor> Professors { get; set; }
}

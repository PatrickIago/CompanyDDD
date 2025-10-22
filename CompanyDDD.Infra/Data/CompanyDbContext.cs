using CompanyDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CompanyDDD.Infra.Data;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
    }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }

}

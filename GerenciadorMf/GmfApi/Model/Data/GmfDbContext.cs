using GmfApi.Models.Data.Map;
using GmfApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GmfApi.Models.Data
{
    public class GmfDbContext : DbContext
    {
        public GmfDbContext(DbContextOptions option) : base(option) 
        { 
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<FuncionarioObra> FuncionarioObras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new ObraMap());
            modelBuilder.ApplyConfiguration(new FuncionarioObraMap());
        }
    }
}

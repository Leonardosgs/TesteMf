using GmfApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GmfApi.Models.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Rg).HasColumnType("varchar").HasMaxLength(9).IsRequired();
            builder.Property(x => x.Salario).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();
        }
    }
}

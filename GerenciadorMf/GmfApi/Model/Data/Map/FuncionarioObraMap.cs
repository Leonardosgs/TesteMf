using GmfApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GmfApi.Models.Data.Map
{
    public class FuncionarioObraMap : IEntityTypeConfiguration<FuncionarioObra>
    {
        public void Configure(EntityTypeBuilder<FuncionarioObra> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DtInicio).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DtFim).HasColumnType("datetime").IsRequired();

        }
    }
}

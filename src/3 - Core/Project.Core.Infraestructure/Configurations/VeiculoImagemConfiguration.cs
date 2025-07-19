using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class VeiculoImagemConfiguration : IEntityTypeConfiguration<VeiculoImagem>
    {
        public void Configure(EntityTypeBuilder<VeiculoImagem> builder)
        {
            builder.ToTable("VeiculoImagem","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.Url).HasColumnType("varchar").IsRequired();

            builder.Property(p => p.Ordem).HasColumnType("int");

            builder.Property(p => p.VeiculoId).HasColumnType("int").IsRequired();


        }
    }
}

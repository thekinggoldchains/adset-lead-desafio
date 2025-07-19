using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.MarcaId).HasColumnType("int").IsRequired();

            builder.Property(p => p.Modelo).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.Property(p => p.Ano).HasColumnType("int").IsRequired();

            builder.Property(p => p.Placa).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            builder.Property(p => p.Km).HasColumnType("int");

            builder.Property(p => p.Cor).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.Property(p => p.Preco).HasColumnType("decimal").IsRequired();


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class OpcionalVeiculoConfiguration : IEntityTypeConfiguration<OpcionalVeiculo>
    {
        public void Configure(EntityTypeBuilder<OpcionalVeiculo> builder)
        {
            builder.ToTable("OpcionalVeiculo","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.VeiculoId).HasColumnType("int").IsRequired();

            builder.Property(p => p.OpcionalId).HasColumnType("int").IsRequired();


        }
    }
}

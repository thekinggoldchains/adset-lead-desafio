using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class VeiculoPortalPacoteConfiguration : IEntityTypeConfiguration<VeiculoPortalPacote>
    {
        public void Configure(EntityTypeBuilder<VeiculoPortalPacote> builder)
        {
            builder.ToTable("VeiculoPortalPacote","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.VeiculoId).HasColumnType("int").IsRequired();

            builder.Property(p => p.VeiculoId).HasColumnType("int").IsRequired();

            builder.Property(p => p.PortalId).HasColumnType("int").IsRequired();

            builder.Property(p => p.PortalId).HasColumnType("int").IsRequired();

            builder.Property(p => p.PacoteId).HasColumnType("int").IsRequired();


        }
    }
}

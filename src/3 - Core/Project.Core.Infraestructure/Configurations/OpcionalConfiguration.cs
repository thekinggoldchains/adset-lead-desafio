using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class OpcionalConfiguration : IEntityTypeConfiguration<Opcional>
    {
        public void Configure(EntityTypeBuilder<Opcional> builder)
        {
            builder.ToTable("Opcional","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();


        }
    }
}

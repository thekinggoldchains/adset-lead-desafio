using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class PacoteConfiguration : IEntityTypeConfiguration<Pacote>
    {
        public void Configure(EntityTypeBuilder<Pacote> builder)
        {
            builder.ToTable("Pacote","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();


        }
    }
}

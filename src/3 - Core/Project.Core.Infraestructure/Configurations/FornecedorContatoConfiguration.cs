using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Configurations
{
    public class FornecedorContatoConfiguration : IEntityTypeConfiguration<FornecedorContato>
    {
        public void Configure(EntityTypeBuilder<FornecedorContato> builder)
        {
            builder.ToTable("FornecedorContato","dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(250);

            builder.Property(p => p.FornecedorId).HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(p => p.Id).HasColumnType("int").IsRequired();

            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(p => p.Telefone).HasColumnType("varchar").HasMaxLength(20);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project.Core.Infraestructure.Entities;

namespace Project.Core.Infraestructure.Context
{
    public partial class DbContextCore : DbContext
    {
        public DbContextCore() { }

        public DbContextCore(DbContextOptions<DbContextCore> options) : base(options) { }
        public virtual DbSet<FornecedorContato> FornecedorContato { get; set; }
        public virtual DbSet<Opcional> Opcional { get; set; }
        public virtual DbSet<OpcionalVeiculo> OpcionalVeiculo { get; set; }
        public virtual DbSet<Pacote> Pacote { get; set; }
        public virtual DbSet<Portal> Portal { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoCor> VeiculoCor { get; set; }
        public virtual DbSet<VeiculoImagem> VeiculoImagem { get; set; }
        public virtual DbSet<VeiculoMarca> VeiculoMarca { get; set; }
        public virtual DbSet<VeiculoPortalPacote> VeiculoPortalPacote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextCore).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}

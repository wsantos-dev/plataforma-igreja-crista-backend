using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Data.EntitiesConfiguration;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContext : DbContext
    {
        public PlataformaRedencaoDbContext(DbContextOptions<PlataformaRedencaoDbContext> options)
            : base(options)
        { }

        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaRedencaoDbContext).Assembly
            );
        }
    }
}
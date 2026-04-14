using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Infra.Data.Constants;

namespace PlataformaIgrejaCrista.Infra.Data.Context
{
    public class PlataformaIgrejaCristaDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlataformaIgrejaCristaDbContext(DbContextOptions<PlataformaIgrejaCristaDbContext> options)
            : base(options)
        { }

        public DbSet<Church> Churches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.GetTableName()?.StartsWith("AspNet") == true)
                {
                    entity.SetSchema(Schemas.Auth);
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaIgrejaCristaDbContext).Assembly
            );

        }
    }
}
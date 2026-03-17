using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlataformaRedencaoDbContext(DbContextOptions<PlataformaRedencaoDbContext> options)
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

            // forcing the tables to be creating with snake_case conventions
            // because UseSnakeCaseNamingConvention() is applyed only custom tables

            modelBuilder.Entity<ApplicationUser>().ToTable("asp_net_users", Schemas.Auth);
            modelBuilder.Entity<IdentityRole>().ToTable("asp_net_roles", Schemas.Auth);
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("asp_net_user_roles", Schemas.Auth);
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("asp_net_user_claims", Schemas.Auth);
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("asp_net_user_logins", Schemas.Auth);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("asp_net_role_claims", Schemas.Auth);
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("asp_net_user_tokens", Schemas.Auth);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaRedencaoDbContext).Assembly
            );

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // IGNORA OWNED TYPES
                if (entity.IsOwned())
                    continue;

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(
                        property.GetColumnName().ToSnakeCase()
                    );
                }
            }
        }
    }
}
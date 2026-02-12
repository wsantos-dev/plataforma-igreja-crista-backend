using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       /// <summary>
       /// Entity Framework Core configuration for the <see cref="RefreshToken"/> entity.
       /// Defines table mapping, column specifications, and constraints related to
       /// authentication token persistence.
       /// </summary>
       public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
       {
              /// <summary>
              /// Configures the <see cref="RefreshToken"/> entity mapping using the provided builder.
              /// </summary>
              /// <param name="builder">
              /// The <see cref="EntityTypeBuilder{RefreshToken}"/> used to configure the entity.
              /// </param>
              public void Configure(EntityTypeBuilder<RefreshToken> builder)
              {
                     // Maps the entity to the "refresh_token" table within the "security" schema.
                     builder.ToTable("refresh_token", "security");

                     // Primary Key configuration.
                     builder.HasKey(r => r.Id);

                     builder.Property(r => r.Id)
                            .HasColumnName("id");

                     // Foreign key reference to the associated user.
                     builder.Property(r => r.UsuarioId)
                            .HasColumnName("usuario_id")
                            .IsRequired();

                     // The refresh token string (typically a secure random value).
                     builder.Property(r => r.Token)
                            .HasColumnName("token")
                            .IsRequired();

                     // Expiration timestamp (stored as PostgreSQL timestamptz).
                     builder.Property(r => r.ExpiresAt)
                            .HasColumnName("expires_at")
                            .HasColumnType("timestamptz")
                            .IsRequired();

                     // Indicates whether the token has been revoked.
                     builder.Property(r => r.Revoked)
                            .HasColumnName("revoked")
                            .IsRequired();
              }
       }
}

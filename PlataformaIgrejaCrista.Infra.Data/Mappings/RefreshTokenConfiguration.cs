using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
       {
              public void Configure(EntityTypeBuilder<RefreshToken> builder)
              {
                     builder.ToTable("refresh_token", Schemas.Auth);

                     // Primary Key
                     builder.HasKey(rt => rt.Id);

                     builder.Property(rt => rt.Id)
                            .HasColumnName("id")
                            .ValueGeneratedOnAdd();

                     builder.Property(rt => rt.TokenHash)
                            .HasColumnName("token_hash")
                            .IsRequired()
                            .HasMaxLength(88);

                     builder.Property(rt => rt.UserId)
                            .HasColumnName("user_id")
                            .IsRequired()
                            .HasMaxLength(450);

                     builder.Property(rt => rt.ExpiresAt)
                            .HasColumnName("expires_at")
                            .HasColumnType("timestamptz")
                            .IsRequired();

                     builder.Property(rt => rt.Revoked)
                            .HasColumnName("revoked")
                            .IsRequired();

                     // Indexes
                     builder.HasIndex(rt => rt.TokenHash)
                            .IsUnique();

                     builder.HasIndex(rt => rt.UserId);

                     builder.HasIndex(rt => rt.ExpiresAt);
              }
       }
}

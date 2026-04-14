using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Infra.Data.Constants;

namespace PlataformaIgrejaCrista.Infra.Data.Mappings
{
       public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
       {
              public void Configure(EntityTypeBuilder<RefreshToken> builder)
              {
                     builder.ToTable("RefreshToken", Schemas.Auth);

                     // Primary Key
                     builder.HasKey(rt => rt.Id);

                     builder.Property(rt => rt.Id)

                            .ValueGeneratedOnAdd();

                     builder.Property(rt => rt.TokenHash)
                            .IsRequired()
                            .HasMaxLength(88);

                     builder.Property(rt => rt.UserId)
                            .IsRequired()
                            .HasMaxLength(450);

                     builder.Property(rt => rt.ExpiresAt)
                            .IsRequired();

                     builder.Property(rt => rt.Revoked)
                            .IsRequired();

                     // Indexes
                     builder.HasIndex(rt => rt.TokenHash)
                            .IsUnique();

                     builder.HasIndex(rt => rt.UserId);

                     builder.HasIndex(rt => rt.ExpiresAt);
              }
       }
}

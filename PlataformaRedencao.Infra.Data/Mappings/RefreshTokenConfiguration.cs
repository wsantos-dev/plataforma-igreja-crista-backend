using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refresh_token", "seguranca");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                   .HasColumnName("id");

            builder.Property(r => r.UsuarioId)
                   .HasColumnName("usuario_id")
                   .IsRequired();

            builder.Property(r => r.Token)
                   .HasColumnName("token")
                   .IsRequired();

            builder.Property(r => r.ExpiresAt)
                   .HasColumnName("expires_at")
                   .HasColumnType("timestamptz")
                   .IsRequired();

            builder.Property(r => r.Revoked)
                   .HasColumnName("revoked")
                   .IsRequired();
        }
    }
}
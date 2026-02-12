using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class UserConfiguration : IEntityTypeConfiguration<User>
       {
              public void Configure(EntityTypeBuilder<User> builder)
              {
                     builder.ToTable("user", "security");

                     builder.HasKey(u => u.Id);

                     builder.Property(i => i.Id)
                            .HasColumnName("id");

                     builder.Property(u => u.EmailAddress)
                            .HasColumnName("email_address")
                            .HasMaxLength(150)
                            .IsRequired();

                     builder.Property(u => u.PasswordHash)
                            .HasColumnName("password_hash")
                            .HasMaxLength(255)
                            .IsRequired();

                     builder.Property(u => u.Role)
                            .HasMaxLength(50)
                            .HasColumnName("role")
                            .IsRequired();

                     builder.Property(u => u.IsActive)
                            .HasColumnName("active")
                            .IsRequired();

                     builder.Property(u => u.CreatedAt)
                            .HasColumnName("created_at")
                            .HasColumnType("timestamptz")
                            .IsRequired();
              }
       }
}
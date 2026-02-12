using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings;

/// <summary>
/// Entity Framework Core configuration for the <see cref="Church"/> entity.
/// Defines table mapping, column specifications, constraints, and relationships.
/// </summary>
public class ChurchConfiguration : IEntityTypeConfiguration<Church>
{
    /// <summary>
    /// Configures the <see cref="Church"/> entity mapping using the provided builder.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="EntityTypeBuilder{Church}"/> used to configure the entity.
    /// </param>
    public void Configure(EntityTypeBuilder<Church> builder)
    {
        // Maps the entity to the "church" table within the "secretary" schema.
        builder.ToTable("church", "secretary");

        // Primary Key configuration.
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        // Church identification and institutional data.
        builder.Property(c => c.OfficialName)
            .HasColumnName("official_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.TradeName)
            .HasColumnName("trade_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Denomination)
            .HasColumnName("denomination")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(c => c.LeadPastor)
            .HasColumnName("lead_pastor")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.FoundationDate)
            .HasColumnName("foundation_date")
            .IsRequired();

        builder.Property(c => c.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Website)
            .HasColumnName("website")
            .HasMaxLength(200)
            .IsRequired();

        // Auditing fields.
        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz") // PostgreSQL timestamp with time zone.
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz");

        // Optional foreign key reference to Address.
        builder.Property(c => c.AddressId)
            .HasColumnName("address_id")
            .IsRequired(false);

        builder.HasOne(c => c.Address)
            .WithMany()
            .HasForeignKey(c => c.AddressId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete.
    }
}

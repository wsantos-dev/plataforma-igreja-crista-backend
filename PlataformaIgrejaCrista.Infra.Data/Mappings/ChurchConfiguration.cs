using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Infra.Data.Constants;

namespace PlataformaIgrejaCrista.Infra.Data.Mappings;

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
        builder.ToTable("Church", Schemas.Secretary);

        // Primary Key configuration.
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id);

        // Church identification and institutional data.
        builder.Property(c => c.OfficialName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.TradeName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Denomination)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(c => c.LeadPastor)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.FoundationDate)
            .IsRequired();

        builder.Property(c => c.Cnpj)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Website)
            .HasMaxLength(200)
            .IsRequired();

        // Auditing fields.
        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.UpdatedAt);

        // Optional foreign key reference to Address.
        builder.Property(c => c.AddressId)
            .IsRequired(false);

        builder.HasOne(c => c.Address)
            .WithMany()
            .HasForeignKey(c => c.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

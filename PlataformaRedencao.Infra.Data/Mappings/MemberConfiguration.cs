using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Infra.Data.Mappings;

/// <summary>
/// Entity Framework Core configuration for the <see cref="Member"/> entity.
/// Defines table mapping, value object conversions, owned types, enum conversions,
/// foreign keys, and auditing fields.
/// </summary>
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    /// <summary>
    /// Configures the <see cref="Member"/> entity mapping using the provided builder.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="EntityTypeBuilder{Member}"/> used to configure the entity.
    /// </param>
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        // Maps the entity to the "member" table within the "secretary" schema.
        builder.ToTable("member", "secretary");

        // Primary Key configuration.
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("id");

        // =============================
        // CPF (Value Object)
        // =============================
        // Maps the Cpf value object to a single column using value conversion.
        builder.Property(m => m.Cpf)
            .HasColumnName("cpf")
            .HasConversion(
                v => v!.Value,     // Converts Value Object to primitive for persistence.
                v => new Cpf(v))   // Rehydrates Value Object from database value.
            .HasMaxLength(14)
            .IsRequired(false);

        // =============================
        // PersonName (Owned Type)
        // =============================
        // Configures FullName as an owned entity type (value object pattern).
        builder.OwnsOne(m => m.FullName, name =>
        {
            name.Property(n => n.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            name.Property(n => n.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(150)
                .IsRequired();
        });

        // =============================
        // BirthDate
        // =============================
        builder.Property(m => m.BirthDate)
            .HasColumnName("birth_date")
            .HasColumnType("date")
            .IsRequired();

        // =============================
        // Gender (Enum)
        // =============================
        // Stores enum as integer in the database.
        builder.Property(m => m.Gender)
            .HasColumnName("gender")
            .HasConversion<int>()
            .IsRequired(false);

        // =============================
        // Contact (Owned Type)
        // =============================
        // Configures Contact as an owned type containing value objects.
        builder.OwnsOne(m => m.Contact, contact =>
        {
            contact.Property(c => c.EmailAddress)
                .HasColumnName("email_address")
                .HasMaxLength(255)
                .HasConversion(
                    v => v!.Address,
                    v => new EmailAddress(v))
                .IsRequired();

            contact.Property(c => c.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(20)
                .HasConversion(
                    v => v!.Number,
                    v => new PhoneNumber(v));
        });

        // =============================
        // Enumerations
        // =============================
        builder.Property(m => m.MaritalStatus)
            .HasColumnName("marital_status")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.EducationLevel)
            .HasColumnName("education_level")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.AdmissionType)
            .HasColumnName("admission_type")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        // =============================
        // AdmissionDate
        // =============================
        builder.Property(m => m.AdmissionDate)
            .HasColumnName("admission_date")
            .HasColumnType("date")
            .IsRequired();

        // =============================
        // Foreign Keys and Relationships
        // =============================

        builder.Property(m => m.AddressId)
            .HasColumnName("address_id")
            .IsRequired();

        builder.HasOne(m => m.Address)
            .WithMany()
            .HasForeignKey(m => m.AddressId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete.

        builder.Property(m => m.ProfessionId)
            .HasColumnName("profession_id")
            .IsRequired();

        builder.HasOne(m => m.Profession)
            .WithMany()
            .HasForeignKey(m => m.ProfessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.ChurchId)
            .HasColumnName("church_id")
            .IsRequired();

        builder.HasOne(m => m.Church)
            .WithMany()
            .HasForeignKey(m => m.ChurchId)
            .OnDelete(DeleteBehavior.Restrict);

        // =============================
        // Auditing
        // =============================
        builder.Property(m => m.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz") // PostgreSQL timestamp with time zone.
            .IsRequired();

        builder.Property(m => m.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz");
    }
}

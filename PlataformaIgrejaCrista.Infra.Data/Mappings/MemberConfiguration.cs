using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.ValueObjects;
using PlataformaRedencao.Infra.Data.Constants;

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
        builder.ToTable("member", Schemas.Secretary);

        // Primary Key configuration.
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id);

        // =============================
        // CPF (Value Object)
        // =============================
        // Maps the Cpf value object to a single column using value conversion.
        builder.Property(m => m.Cpf)
            .HasConversion(
                v => v!.Value,     // Converts Value Object to primitive for persistence.
                v => new Cpf(v))   // Rehydrates Value Object from database value.
            .HasMaxLength(14)
            .IsRequired(false);


        builder.OwnsOne(m => m.FullName, fullname =>
        {
            fullname.Property(n => n.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name")
                .IsRequired();

            fullname.Property(n => n.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");

            fullname.Property(n => n.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(150)
                .IsRequired();
        });

        // =============================
        // BirthDate
        // =============================
        builder.Property(m => m.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        // =============================
        // Gender (Enum)
        // =============================
        // Stores enum as char in the database.
        builder.Property(m => m.Gender)
       .HasConversion(
            g => g!.Code,
            c => Gender.FromCode(c)
        )
       .HasColumnType("char(1)")
       .IsRequired();

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
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.EducationLevel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.AdmissionType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(m => m.Status)
            .HasConversion<int>()
            .IsRequired();

        // =============================
        // AdmissionDate
        // =============================
        builder.Property(m => m.AdmissionDate)
            .HasColumnType("date")
            .IsRequired();

        // =============================
        // Foreign Keys and Relationships
        // =============================

        builder.Property(m => m.AddressId)
            .IsRequired();

        builder.HasOne(m => m.Address)
            .WithMany()
            .HasForeignKey(m => m.AddressId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete.

        builder.Property(m => m.ProfessionId)
            .IsRequired();

        builder.HasOne(m => m.Profession)
            .WithMany()
            .HasForeignKey(m => m.ProfessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.ChurchId)
            .IsRequired();

        builder.HasOne(m => m.Church)
            .WithMany()
            .HasForeignKey(m => m.ChurchId)
            .OnDelete(DeleteBehavior.Restrict);

        // =============================
        // Auditing
        // =============================
        builder.Property(m => m.CreatedAt)
            .HasColumnType("timestamptz") // PostgreSQL timestamp with time zone.
            .IsRequired();

        builder.Property(m => m.UpdatedAt)
            .HasColumnType("timestamptz");

        builder.Property(m => m.ApplicationUserId)
               .HasMaxLength(450)
               .IsRequired();

        builder.HasIndex(m => m.ApplicationUserId)
               .IsUnique();

        builder.HasOne<ApplicationUser>()
               .WithOne()
               .HasForeignKey<Member>(m => m.ApplicationUserId)
               .HasPrincipalKey<ApplicationUser>(u => u.Id)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

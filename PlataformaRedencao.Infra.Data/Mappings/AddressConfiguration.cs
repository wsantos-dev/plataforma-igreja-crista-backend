using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    /// <summary>
    /// Entity Framework Core configuration for the <see cref="Address"/> entity.
    /// Defines table mapping, column configuration, constraints, and indexes.
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Configures the <see cref="Address"/> entity mapping using the provided builder.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="EntityTypeBuilder{Address}"/> used to configure the entity.
        /// </param>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Maps the entity to the "address" table within the "secretary" schema.
            builder.ToTable("address", "secretary");

            // Primary Key configuration.
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            // Owner entity identification (polymorphic association).
            builder.Property(e => e.EntityId)
                .HasColumnName("entity_id")
                .IsRequired();

            builder.Property(e => e.EntityType)
                .HasColumnName("entity_type")
                .HasConversion<int>() // Stores enum as integer in the database.
                .IsRequired();

            // Address core fields.
            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Number)
                .HasColumnName("number")
                .HasMaxLength(20);

            builder.Property(e => e.Complement)
                .HasColumnName("complement")
                .HasMaxLength(100);

            builder.Property(e => e.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(100);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasColumnName("postalcode")
                .HasMaxLength(20)
                .IsRequired();

            // Composite index to optimize queries by owner entity.
            builder.HasIndex(e => new { e.EntityId, e.EntityType });
        }
    }
}

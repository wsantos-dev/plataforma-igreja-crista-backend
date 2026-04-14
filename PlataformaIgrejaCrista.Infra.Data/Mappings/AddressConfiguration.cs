using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Infra.Data.Constants;

namespace PlataformaIgrejaCrista.Infra.Data.Mappings
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
            builder.ToTable("Address", Schemas.Secretary);


            // Primary Key configuration.
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            // Owner entity identification (polymorphic association).
            builder.Property(e => e.EntityId)
                .IsRequired();

            builder.Property(e => e.EntityType)
                .HasConversion<int>() // Stores enum as integer in the database.
                .IsRequired();

            // Address core fields.
            builder.Property(e => e.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Number)
                .HasMaxLength(20);

            builder.Property(e => e.Complement)
                .HasMaxLength(100);

            builder.Property(e => e.Neighborhood)
                .HasMaxLength(100);

            builder.Property(e => e.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.State)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsRequired();

            // Composite index to optimize queries by owner entity.
            builder.HasIndex(e => new { e.EntityId, e.EntityType });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       /// <summary>
       /// Entity Framework Core configuration for the <see cref="Profession"/> entity.
       /// Defines table mapping and column constraints.
       /// </summary>
       public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
       {
              /// <summary>
              /// Configures the <see cref="Profession"/> entity mapping using the provided builder.
              /// </summary>
              /// <param name="builder">
              /// The <see cref="EntityTypeBuilder{Profession}"/> used to configure the entity.
              /// </param>
              public void Configure(EntityTypeBuilder<Profession> builder)
              {
                     // Maps the entity to the "profession" table within the "secretary" schema.
                     builder.ToTable("profession", Schemas.Secretary);

                     // Primary Key configuration.
                     builder.HasKey(p => p.Id);

                     builder.Property(p => p.Id);

                     // Optional profession code (e.g., internal or regulatory identifier).
                     builder.Property(p => p.Code)
                            .HasMaxLength(30);

                     // Profession name (required).
                     builder.Property(p => p.Term)
                            .HasMaxLength(150)
                            .IsRequired();

              }
       }
}

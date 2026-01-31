using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class AssinaturaEletronicaConfiguration : IEntityTypeConfiguration<AssinaturaEletronica>
       {
              public void Configure(EntityTypeBuilder<AssinaturaEletronica> builder)
              {
                     builder.ToTable("assinatura_eletronica", "membros");

                     builder.HasKey(a => a.Id);
                     builder.Property(a => a.Id).HasColumnName("id");

                     builder.Property(a => a.ConsentimentoId)
                            .HasColumnName("consentimento_id")
                            .IsRequired();

                     builder.HasOne(a => a.Consentimento)
                            .WithMany() // Se Consentimento tiver coleção de assinaturas: .WithMany(c => c.Assinaturas)
                            .HasForeignKey(a => a.ConsentimentoId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.Property(a => a.Provedor)
                            .HasColumnName("provedor")
                            .IsRequired();

                     builder.Property(a => a.Tipo)
                            .HasColumnName("tipo")
                            .IsRequired();

                     builder.Property(a => a.DataAssinatura)
                            .HasColumnName("data_assinatura")
                            .IsRequired();

                     builder.Property(a => a.HashDocumento)
                            .HasColumnName("hash_documento")
                            .HasMaxLength(4000);

                     builder.Property(a => a.IdentificadorAssinatura)
                            .HasColumnName("identificador_assinatura")
                            .HasMaxLength(200);

                     builder.Property(a => a.Certificado)
                            .HasColumnName("certificado")
                            .HasMaxLength(4000);
              }
       }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class TermoConsentimentoConfiguration : IEntityTypeConfiguration<TermoConsentimento>
       {
              public void Configure(EntityTypeBuilder<TermoConsentimento> builder)
              {
                     builder.ToTable("termo_consentimento", "membros");

                     builder.HasKey(t => t.Id);
                     builder.Property(t => t.Id).HasColumnName("id");

                     builder.Property(t => t.Tipo)
                            .HasColumnName("tipo")
                            .IsRequired();

                     builder.Property(t => t.Conteudo)
                            .HasColumnName("conteudo")
                            .HasMaxLength(4000)
                            .IsRequired();

                     builder.Property(t => t.Versao)
                            .HasColumnName("versao")
                            .HasMaxLength(50)
                            .IsRequired();

                     builder.Property(t => t.VigenciaInicio)
                            .HasColumnName("vigencia_inicio")
                            .IsRequired();

                     builder.Property(t => t.VigenciaFim)
                            .HasColumnName("vigencia_fim");
              }
       }
}

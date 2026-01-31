using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class ConsentimentoConfiguration : IEntityTypeConfiguration<Consentimento>
       {
              public void Configure(EntityTypeBuilder<Consentimento> builder)
              {

                     builder.ToTable("consentimento", "membros");

                     builder.HasKey(c => c.Id);
                     builder.Property(c => c.Id).HasColumnName("id");

                     builder.Property(c => c.Tipo)
                            .HasColumnName("tipo")
                            .IsRequired();

                     builder.Property(c => c.DataConcessao)
                            .HasColumnName("data_concessao")
                            .IsRequired();

                     builder.Property(c => c.DataRevogacao)
                            .HasColumnName("data_revogacao");

                     builder.Property(c => c.MembroId)
                            .HasColumnName("membro_id")
                            .IsRequired();

                     builder.HasOne(c => c.Membro)
                            .WithMany()
                            .HasForeignKey(c => c.MembroId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.Property(c => c.TermoConsentimentoId)
                            .HasColumnName("termo_consentimento_id")
                            .IsRequired();

                     builder.HasOne(c => c.TermoConsentimento)
                            .WithMany()
                            .HasForeignKey(c => c.TermoConsentimentoId)
                            .OnDelete(DeleteBehavior.Restrict);
              }
       }
}

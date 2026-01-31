using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class ProfissaoConfiguration : IEntityTypeConfiguration<Profissao>
       {
              public void Configure(EntityTypeBuilder<Profissao> builder)
              {
                     builder.ToTable("profissao", "membros");

                     builder.HasKey(p => p.Id);
                     builder.Property(p => p.Id)
                            .HasColumnName("id");

                     builder.Property(p => p.Nome)
                            .HasColumnName("nome")
                            .HasMaxLength(150)
                            .IsRequired();

                     builder.Property(p => p.Codigo)
                            .HasColumnName("codigo")
                            .HasMaxLength(30);

              }
       }
}

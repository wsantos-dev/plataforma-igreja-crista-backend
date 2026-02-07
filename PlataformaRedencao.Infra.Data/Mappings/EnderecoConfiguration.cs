using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco", "membros");

            // PK
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            // Entidade dona do endereço
            builder.Property(e => e.EntidadeId)
                .HasColumnName("entidade_id")
                .IsRequired();

            builder.Property(e => e.TipoEntidade)
                .HasColumnName("tipo_entidade")
                .HasConversion<int>()
                .IsRequired();

            // Dados do endereço
            builder.Property(e => e.Logradouro)
                .HasColumnName("logradouro")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("numero")
                .HasMaxLength(20);

            builder.Property(e => e.Complemento)
                .HasColumnName("complemento")
                .HasMaxLength(100);

            builder.Property(e => e.Bairro)
                .HasColumnName("bairro")
                .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                .HasColumnName("cidade")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Pais)
                .HasColumnName("pais")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .HasMaxLength(20)
                .IsRequired();

            // Controle de vigência
            builder.Property(e => e.Atual)
                .HasColumnName("atual")
                .IsRequired();

            builder.Property(e => e.VigenteDesde)
                .HasColumnName("vigente_desde");

            builder.Property(e => e.VigenteAte)
                .HasColumnName("vigente_ate");

            // Índices úteis
            builder.HasIndex(e => new { e.EntidadeId, e.TipoEntidade });
            builder.HasIndex(e => e.Atual);
        }
    }
}

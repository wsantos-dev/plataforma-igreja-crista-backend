using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings;

public class IgrejaConfiguration : IEntityTypeConfiguration<Igreja>
{
    public void Configure(EntityTypeBuilder<Igreja> builder)
    {
        builder.ToTable("igreja", "membros");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("id");

        builder.Property(i => i.Nome)
            .HasColumnName("nome")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(i => i.NomeFantasia)
            .HasColumnName("nome_fantasia")
            .HasMaxLength(200);

        builder.Property(i => i.Denominacao)
            .HasColumnName("denominacao")
            .HasMaxLength(100);

        builder.Property(i => i.PastorResponsavel)
            .HasColumnName("pastor_responsavel")
            .HasMaxLength(200);

        builder.Property(i => i.DataFundacao)
            .HasColumnName("data_fundacao")
            .IsRequired();

        builder.Property(i => i.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(i => i.Email)
            .HasColumnName("email")
            .HasMaxLength(200);

        builder.Property(i => i.Site)
            .HasColumnName("site")
            .HasMaxLength(200);

        builder.Property(i => i.Ativa)
            .HasColumnName("ativa")
            .IsRequired();

        builder.Property(i => i.CriadaEm)
            .HasColumnName("criada_em")
            .IsRequired();

        builder.Property(i => i.AtualizadaEm)
            .HasColumnName("atualizada_em");

        // FK Endereço (nullable conforme entidade)
        builder.Property(i => i.EnderecoId)
            .HasColumnName("endereco_id")
            .IsRequired(false);

        builder.HasOne(i => i.Endereco)
            .WithMany()
            .HasForeignKey(i => i.EnderecoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
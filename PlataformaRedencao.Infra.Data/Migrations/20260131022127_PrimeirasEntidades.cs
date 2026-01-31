using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlataformaRedencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeirasEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "membros");

            migrationBuilder.CreateTable(
                name: "endereco",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entidade_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_entidade = table.Column<int>(type: "integer", nullable: false),
                    logradouro = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cep = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    atual = table.Column<bool>(type: "boolean", nullable: false),
                    vigente_desde = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    vigente_ate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profissao",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    codigo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profissao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "termo_consentimento",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    conteudo = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    versao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vigencia_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vigencia_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termo_consentimento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "igreja",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    nome_fantasia = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    denominacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    pastor_responsavel = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    data_fundacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    site = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ativa = table.Column<bool>(type: "boolean", nullable: false),
                    criada_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    atualizada_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    endereco_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_igreja", x => x.id);
                    table.ForeignKey(
                        name: "FK_igreja_endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalSchema: "membros",
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membro",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    primeiro_nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    data_nascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    sexo = table.Column<char>(type: "character(1)", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    estado_civil = table.Column<int>(type: "integer", nullable: false),
                    escolaridade = table.Column<int>(type: "integer", nullable: false),
                    profissao_id = table.Column<int>(type: "integer", nullable: false),
                    endereco_id = table.Column<int>(type: "integer", nullable: false),
                    igreja_id = table.Column<int>(type: "integer", nullable: false),
                    data_admissao = table.Column<DateOnly>(type: "date", nullable: false),
                    tipo_admissao = table.Column<int>(type: "integer", nullable: false),
                    situacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membro", x => x.id);
                    table.ForeignKey(
                        name: "FK_membro_endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalSchema: "membros",
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_igreja_igreja_id",
                        column: x => x.igreja_id,
                        principalSchema: "membros",
                        principalTable: "igreja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_membro_profissao_profissao_id",
                        column: x => x.profissao_id,
                        principalSchema: "membros",
                        principalTable: "profissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "consentimento",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    membro_id = table.Column<int>(type: "integer", nullable: false),
                    termo_consentimento_id = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    data_concessao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_revogacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consentimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_consentimento_membro_membro_id",
                        column: x => x.membro_id,
                        principalSchema: "membros",
                        principalTable: "membro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consentimento_termo_consentimento_termo_consentimento_id",
                        column: x => x.termo_consentimento_id,
                        principalSchema: "membros",
                        principalTable: "termo_consentimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assinatura_eletronica",
                schema: "membros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    consentimento_id = table.Column<int>(type: "integer", nullable: false),
                    provedor = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    data_assinatura = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hash_documento = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    identificador_assinatura = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    certificado = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assinatura_eletronica", x => x.id);
                    table.ForeignKey(
                        name: "FK_assinatura_eletronica_consentimento_consentimento_id",
                        column: x => x.consentimento_id,
                        principalSchema: "membros",
                        principalTable: "consentimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assinatura_eletronica_consentimento_id",
                schema: "membros",
                table: "assinatura_eletronica",
                column: "consentimento_id");

            migrationBuilder.CreateIndex(
                name: "IX_consentimento_membro_id",
                schema: "membros",
                table: "consentimento",
                column: "membro_id");

            migrationBuilder.CreateIndex(
                name: "IX_consentimento_termo_consentimento_id",
                schema: "membros",
                table: "consentimento",
                column: "termo_consentimento_id");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_atual",
                schema: "membros",
                table: "endereco",
                column: "atual");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_entidade_id_tipo_entidade",
                schema: "membros",
                table: "endereco",
                columns: new[] { "entidade_id", "tipo_entidade" });

            migrationBuilder.CreateIndex(
                name: "IX_igreja_endereco_id",
                schema: "membros",
                table: "igreja",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_endereco_id",
                schema: "membros",
                table: "membro",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_igreja_id",
                schema: "membros",
                table: "membro",
                column: "igreja_id");

            migrationBuilder.CreateIndex(
                name: "IX_membro_profissao_id",
                schema: "membros",
                table: "membro",
                column: "profissao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assinatura_eletronica",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "consentimento",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "membro",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "termo_consentimento",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "igreja",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "profissao",
                schema: "membros");

            migrationBuilder.DropTable(
                name: "endereco",
                schema: "membros");
        }
    }
}

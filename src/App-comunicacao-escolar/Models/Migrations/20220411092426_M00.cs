using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeiraMensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemetenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemetenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemetenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemetenteId = table.Column<int>(type: "int", nullable: true),
                    listaDestinatarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listaDestinatariosNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversaId = table.Column<int>(type: "int", nullable: true),
                    MensagemRespondidaId = table.Column<int>(type: "int", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Conversas_ConversaId",
                        column: x => x.ConversaId,
                        principalTable: "Conversas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_Mensagem_MensagemRespondidaId",
                        column: x => x.MensagemRespondidaId,
                        principalTable: "Mensagem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConversaUsuario",
                columns: table => new
                {
                    ConversasId = table.Column<int>(type: "int", nullable: false),
                    ParticipantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversaUsuario", x => new { x.ConversasId, x.ParticipantesId });
                    table.ForeignKey(
                        name: "FK_ConversaUsuario_Conversas_ConversasId",
                        column: x => x.ConversasId,
                        principalTable: "Conversas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversaUsuario_Usuarios_ParticipantesId",
                        column: x => x.ParticipantesId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensagemUsuario",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false),
                    ParticipantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemUsuario", x => new { x.MensagemId, x.ParticipantesId });
                    table.ForeignKey(
                        name: "FK_MensagemUsuario_Mensagem_MensagemId",
                        column: x => x.MensagemId,
                        principalTable: "Mensagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensagemUsuario_Usuarios_ParticipantesId",
                        column: x => x.ParticipantesId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversaUsuario_ParticipantesId",
                table: "ConversaUsuario",
                column: "ParticipantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ConversaId",
                table: "Mensagem",
                column: "ConversaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_MensagemRespondidaId",
                table: "Mensagem",
                column: "MensagemRespondidaId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagemUsuario_ParticipantesId",
                table: "MensagemUsuario",
                column: "ParticipantesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversaUsuario");

            migrationBuilder.DropTable(
                name: "MensagemUsuario");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Conversas");
        }
    }
}

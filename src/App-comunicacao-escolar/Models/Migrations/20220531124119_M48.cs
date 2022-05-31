using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Notificacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioLeuNotificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificacaoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    NotificacaoLida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLeuNotificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioLeuNotificacao_Notificacoes_NotificacaoId",
                        column: x => x.NotificacaoId,
                        principalTable: "Notificacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioLeuNotificacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLeuNotificacao_NotificacaoId",
                table: "UsuarioLeuNotificacao",
                column: "NotificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLeuNotificacao_UsuarioId",
                table: "UsuarioLeuNotificacao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioLeuNotificacao");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Notificacoes");
        }
    }
}

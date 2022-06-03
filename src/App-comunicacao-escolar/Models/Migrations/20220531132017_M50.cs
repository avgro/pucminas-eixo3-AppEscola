using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLeuNotificacao_Notificacoes_NotificacaoId",
                table: "UsuarioLeuNotificacao");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLeuNotificacao_Notificacoes_NotificacaoId",
                table: "UsuarioLeuNotificacao",
                column: "NotificacaoId",
                principalTable: "Notificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLeuNotificacao_Notificacoes_NotificacaoId",
                table: "UsuarioLeuNotificacao");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLeuNotificacao_Notificacoes_NotificacaoId",
                table: "UsuarioLeuNotificacao",
                column: "NotificacaoId",
                principalTable: "Notificacoes",
                principalColumn: "Id");
        }
    }
}

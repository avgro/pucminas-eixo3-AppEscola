using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLeuNotificacao_Usuarios_UsuarioId",
                table: "UsuarioLeuNotificacao");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLeuNotificacao_Usuarios_UsuarioId",
                table: "UsuarioLeuNotificacao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioLeuNotificacao_Usuarios_UsuarioId",
                table: "UsuarioLeuNotificacao");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioLeuNotificacao_Usuarios_UsuarioId",
                table: "UsuarioLeuNotificacao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

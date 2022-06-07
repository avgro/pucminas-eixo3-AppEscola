using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificacaoLida",
                table: "UsuarioLeuNotificacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotificacaoLida",
                table: "UsuarioLeuNotificacao",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossuiMensagensNaoLidas",
                table: "NumeroDeNovasMensagensNaConversa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PossuiMensagensNaoLidas",
                table: "NumeroDeNovasMensagensNaConversa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

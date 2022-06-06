using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "PostagensLinhaDoTempo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostagensLinhaDoTempo_AutorId",
                table: "PostagensLinhaDoTempo",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostagensLinhaDoTempo_Usuarios_AutorId",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.DropIndex(
                name: "IX_PostagensLinhaDoTempo_AutorId",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "PostagensLinhaDoTempo");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "PostagensLinhaDoTempo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}

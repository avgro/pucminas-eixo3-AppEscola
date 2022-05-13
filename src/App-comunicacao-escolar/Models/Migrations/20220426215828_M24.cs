using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id");
        }
    }
}

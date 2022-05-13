using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosDasDisciplinas_Disciplinas_DisciplinaId",
                table: "HorariosDasDisciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosDasDisciplinas_Disciplinas_DisciplinaId",
                table: "HorariosDasDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosDasDisciplinas_Disciplinas_DisciplinaId",
                table: "HorariosDasDisciplinas");

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosDasDisciplinas_Disciplinas_DisciplinaId",
                table: "HorariosDasDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id");
        }
    }
}

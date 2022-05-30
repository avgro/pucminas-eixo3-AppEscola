using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Agendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TurmaId",
                table: "Agendas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Turmas_TurmaId",
                table: "Agendas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Turmas_TurmaId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_TurmaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Agendas");
        }
    }
}

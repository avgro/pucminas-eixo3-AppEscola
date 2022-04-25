using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessor",
                columns: table => new
                {
                    DisciplinasId = table.Column<int>(type: "int", nullable: false),
                    ProfessoresProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessor", x => new { x.DisciplinasId, x.ProfessoresProfessorId });
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Professores_ProfessoresProfessorId",
                        column: x => x.ProfessoresProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessor_ProfessoresProfessorId",
                table: "DisciplinaProfessor",
                column: "ProfessoresProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaProfessor");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_comunicacao_escolar.Migrations
{
    public partial class M23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NomeComCodigoEntreParenteses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Disciplinas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infrastructure.Data.Migrations
{
    public partial class AtualizandoEntidades1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatriculaAtiva",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MatriculaAtiva",
                table: "Alunos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

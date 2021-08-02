using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infrastructure.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Idioma = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    MatriculaAtiva = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}

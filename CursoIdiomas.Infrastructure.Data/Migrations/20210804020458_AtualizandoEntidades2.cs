using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infrastructure.Data.Migrations
{
    public partial class AtualizandoEntidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ChaveTurma",
                table: "Alunos",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveTurma",
                table: "Alunos");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurmaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}

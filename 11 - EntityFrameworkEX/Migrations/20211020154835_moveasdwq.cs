using Microsoft.EntityFrameworkCore.Migrations;

namespace _11___EntityFrameworkEX.Migrations
{
    public partial class moveasdwq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moveset_SuperHeroes_SuperheroId",
                table: "Moveset");

            migrationBuilder.RenameColumn(
                name: "SuperheroId",
                table: "Moveset",
                newName: "SuperheroID");

            migrationBuilder.RenameIndex(
                name: "IX_Moveset_SuperheroId",
                table: "Moveset",
                newName: "IX_Moveset_SuperheroID");

            migrationBuilder.AlterColumn<int>(
                name: "SuperheroID",
                table: "Moveset",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moveset_SuperHeroes_SuperheroID",
                table: "Moveset",
                column: "SuperheroID",
                principalTable: "SuperHeroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moveset_SuperHeroes_SuperheroID",
                table: "Moveset");

            migrationBuilder.RenameColumn(
                name: "SuperheroID",
                table: "Moveset",
                newName: "SuperheroId");

            migrationBuilder.RenameIndex(
                name: "IX_Moveset_SuperheroID",
                table: "Moveset",
                newName: "IX_Moveset_SuperheroId");

            migrationBuilder.AlterColumn<int>(
                name: "SuperheroId",
                table: "Moveset",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Moveset_SuperHeroes_SuperheroId",
                table: "Moveset",
                column: "SuperheroId",
                principalTable: "SuperHeroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

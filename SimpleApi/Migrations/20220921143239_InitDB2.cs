using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApi.Migrations
{
    public partial class InitDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Power_Heroe_superHeroID",
                table: "Power");

            migrationBuilder.DropIndex(
                name: "IX_Power_superHeroID",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "superHeroID",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Heroe");

            migrationBuilder.AddColumn<int>(
                name: "PowerID",
                table: "Heroe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroe_PowerID",
                table: "Heroe",
                column: "PowerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroe_Power_PowerID",
                table: "Heroe",
                column: "PowerID",
                principalTable: "Power",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroe_Power_PowerID",
                table: "Heroe");

            migrationBuilder.DropIndex(
                name: "IX_Heroe_PowerID",
                table: "Heroe");

            migrationBuilder.DropColumn(
                name: "PowerID",
                table: "Heroe");

            migrationBuilder.AddColumn<int>(
                name: "superHeroID",
                table: "Power",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Heroe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Power_superHeroID",
                table: "Power",
                column: "superHeroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Power_Heroe_superHeroID",
                table: "Power",
                column: "superHeroID",
                principalTable: "Heroe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleApi.Migrations
{
    public partial class InitDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroe_Power_PowerID",
                table: "Heroe");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropIndex(
                name: "IX_Heroe_PowerID",
                table: "Heroe");

            migrationBuilder.DropColumn(
                name: "PowerID",
                table: "Heroe");

            migrationBuilder.AddColumn<string>(
                name: "PowerName",
                table: "Heroe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerName",
                table: "Heroe");

            migrationBuilder.AddColumn<int>(
                name: "PowerID",
                table: "Heroe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroeID = table.Column<int>(type: "int", nullable: false),
                    PowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.ID);
                });

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CofMath.Migrations
{
    public partial class AddMigration123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroundCoffee = table.Column<int>(type: "int", nullable: false),
                    Water = table.Column<int>(type: "int", nullable: false),
                    Milk = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroundCoffee = table.Column<int>(type: "int", nullable: false),
                    Water = table.Column<int>(type: "int", nullable: false),
                    Milk = table.Column<int>(type: "int", nullable: false),
                    Sugar = table.Column<int>(type: "int", nullable: false),
                    Cup = table.Column<int>(type: "int", nullable: false),
                    Handing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}

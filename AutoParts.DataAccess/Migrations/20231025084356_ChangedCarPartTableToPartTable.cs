using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCarPartTableToPartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarParts");

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "Description", "PartName" },
                values: new object[,]
                {
                    { 1, "Engine Cover", "Bonnet" },
                    { 2, "Above Right Wheel", "Right Guard" },
                    { 3, "Cover Driver", "Right Door" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.CreateTable(
                name: "CarParts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParts", x => x.PartId);
                });

            migrationBuilder.InsertData(
                table: "CarParts",
                columns: new[] { "PartId", "DisplayOrder", "Manufacturer", "Model", "PartName", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Toyota", "Corolla", "Bonnet", "2023" },
                    { 2, 2, "VW", "Golf", "Right Guard", "2019" },
                    { 3, 3, "Audi", "A8", "Right Door", "2016" }
                });
        }
    }
}

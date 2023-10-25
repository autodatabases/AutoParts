using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceRazor.Migrations
{
    /// <inheritdoc />
    public partial class CarPartToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarParts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
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
                    { 1, 1, "Nissan", "Maxima", "Compressor", "2006" },
                    { 2, 3, "Ford", "Ecosports", "Rear Prop Shaft", "2010" },
                    { 3, 4, "Hyundai", "Tucson", "Combination Switch", "2020" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarParts");
        }
    }
}

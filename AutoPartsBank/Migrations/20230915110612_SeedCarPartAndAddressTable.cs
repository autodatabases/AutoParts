using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoPartsBank.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarPartAndAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Postcode", "State", "Street", "Suburb" },
                values: new object[,]
                {
                    { 1, "2144", "NSW", "10 Park Road", "Auburn" },
                    { 2, "2135", "NSW", "42 Swan Avenue", "Strathfield" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "PartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "PartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarParts",
                keyColumn: "PartId",
                keyValue: 3);
        }
    }
}

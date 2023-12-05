using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyRelationBetweenVehicleAndVendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VIN",
                keyValue: "1234ASDF",
                column: "VendorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VIN",
                keyValue: "1235",
                column: "VendorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VIN",
                keyValue: "1236",
                column: "VendorId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VendorId",
                table: "Vehicles",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Vendors_VendorId",
                table: "Vehicles",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Vendors_VendorId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VendorId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Vehicles");
        }
    }
}

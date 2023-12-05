using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyRelationBetweenVehicleAndPartCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "PartCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "VIN",
                value: "1234ASDF");

            migrationBuilder.UpdateData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "VIN",
                value: "1235");

            migrationBuilder.UpdateData(
                table: "PartCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "VIN",
                value: "1236");

            migrationBuilder.CreateIndex(
                name: "IX_PartCategories_VIN",
                table: "PartCategories",
                column: "VIN");

            migrationBuilder.AddForeignKey(
                name: "FK_PartCategories_Vehicles_VIN",
                table: "PartCategories",
                column: "VIN",
                principalTable: "Vehicles",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartCategories_Vehicles_VIN",
                table: "PartCategories");

            migrationBuilder.DropIndex(
                name: "IX_PartCategories_VIN",
                table: "PartCategories");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "PartCategories");
        }
    }
}

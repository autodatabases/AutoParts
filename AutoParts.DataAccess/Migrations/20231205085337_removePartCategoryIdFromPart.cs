using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removePartCategoryIdFromPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartCategoryId",
                table: "Parts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartCategoryId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1,
                column: "PartCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2,
                column: "PartCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "PartCategoryId",
                value: 3);
        }
    }
}

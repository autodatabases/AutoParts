using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageUrlToPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "ImageUrl",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Parts");
        }
    }
}

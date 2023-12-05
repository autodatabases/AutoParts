using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyRelationBetweenPartAndPartCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CategoryId",
                table: "Parts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartCategories_CategoryId",
                table: "Parts",
                column: "CategoryId",
                principalTable: "PartCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartCategories_CategoryId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CategoryId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Parts");
        }
    }
}

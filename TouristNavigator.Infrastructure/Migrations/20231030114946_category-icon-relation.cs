using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class categoryiconrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryIcon_IconId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IconId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryIcon_CategoryId",
                table: "CategoryIcon",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryIcon_Categories_CategoryId",
                table: "CategoryIcon",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryIcon_Categories_CategoryId",
                table: "CategoryIcon");

            migrationBuilder.DropIndex(
                name: "IX_CategoryIcon_CategoryId",
                table: "CategoryIcon");

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IconId",
                table: "Categories",
                column: "IconId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryIcon_IconId",
                table: "Categories",
                column: "IconId",
                principalTable: "CategoryIcon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

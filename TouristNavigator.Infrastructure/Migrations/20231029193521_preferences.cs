using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class preferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Categories_CategoryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CategoryId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Places");

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserPreferences_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_CategoryId",
                table: "UserPreferences",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Categories_CategoryId",
                table: "Places",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

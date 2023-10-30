using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class categoryicon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconData",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryIcon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryIcon", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryIcon_IconId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryIcon");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IconId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Categories");

            migrationBuilder.AddColumn<byte[]>(
                name: "IconData",
                table: "Categories",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}

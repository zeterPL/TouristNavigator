using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class placephoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryIcon_Categories_CategoryId",
                table: "CategoryIcon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryIcon",
                table: "CategoryIcon");

            migrationBuilder.RenameTable(
                name: "CategoryIcon",
                newName: "CategoryIcons");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryIcon_CategoryId",
                table: "CategoryIcons",
                newName: "IX_CategoryIcons_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryIcons",
                table: "CategoryIcons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlacesPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesPhotos_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacesPhotos_PlaceId",
                table: "PlacesPhotos",
                column: "PlaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryIcons_Categories_CategoryId",
                table: "CategoryIcons",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryIcons_Categories_CategoryId",
                table: "CategoryIcons");

            migrationBuilder.DropTable(
                name: "PlacesPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryIcons",
                table: "CategoryIcons");

            migrationBuilder.RenameTable(
                name: "CategoryIcons",
                newName: "CategoryIcon");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryIcons_CategoryId",
                table: "CategoryIcon",
                newName: "IX_CategoryIcon_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryIcon",
                table: "CategoryIcon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryIcon_Categories_CategoryId",
                table: "CategoryIcon",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

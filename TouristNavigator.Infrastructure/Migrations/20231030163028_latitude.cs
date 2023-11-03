using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class latitude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Latitute",
                table: "Places",
                newName: "Latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Places",
                newName: "Latitute");
        }
    }
}

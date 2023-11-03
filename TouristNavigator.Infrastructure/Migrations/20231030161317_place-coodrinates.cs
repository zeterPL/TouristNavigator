using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class placecoodrinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitute",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitute",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Places");
        }
    }
}

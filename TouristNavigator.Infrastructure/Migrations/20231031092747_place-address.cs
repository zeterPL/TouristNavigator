using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class placeaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress_City",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adress_Country",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adress_LocalNumber",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress_PostalCode",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Adress_Street",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress_City",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Adress_Country",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Adress_LocalNumber",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Adress_PostalCode",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Adress_Street",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Places");
        }
    }
}

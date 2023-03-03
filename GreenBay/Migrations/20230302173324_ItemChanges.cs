using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay.Migrations
{
    /// <inheritdoc />
    public partial class ItemChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "StartingPrice");

            migrationBuilder.AddColumn<double>(
                name: "CurrentPrice",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FinalPrice",
                table: "Items",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "StartingPrice",
                table: "Items",
                newName: "Price");
        }
    }
}

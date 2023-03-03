using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay.Migrations
{
    /// <inheritdoc />
    public partial class ColumnSold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sold",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sold",
                table: "Items");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chines_auction_project.Migrations
{
    /// <inheritdoc />
    public partial class _11_changeDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Donor");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Donor");
        }
    }
}

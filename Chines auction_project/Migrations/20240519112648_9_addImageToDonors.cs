using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chines_auction_project.Migrations
{
    /// <inheritdoc />
    public partial class _9_addImageToDonors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Donor");
        }
    }
}

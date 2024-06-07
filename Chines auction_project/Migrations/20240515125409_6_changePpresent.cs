using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chines_auction_project.Migrations
{
    /// <inheritdoc />
    public partial class _6_changePpresent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Present",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present",
                column: "WinnerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Present",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present",
                column: "WinnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

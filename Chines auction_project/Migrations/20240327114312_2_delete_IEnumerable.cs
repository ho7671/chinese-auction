using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chines_auction_project.Migrations
{
    /// <inheritdoc />
    public partial class _2_delete_IEnumerable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Present_presentId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_presentId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "presentId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Present",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Present_PurchaseId",
                table: "Present",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present");

            migrationBuilder.DropIndex(
                name: "IX_Present_PurchaseId",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Present");

            migrationBuilder.AddColumn<int>(
                name: "presentId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_presentId",
                table: "Purchase",
                column: "presentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Present_presentId",
                table: "Purchase",
                column: "presentId",
                principalTable: "Present",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

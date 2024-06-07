using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chines_auction_project.Migrations
{
    /// <inheritdoc />
    public partial class _3_changeDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Purchase_PurchaseId",
                table: "Present");

            migrationBuilder.DropIndex(
                name: "IX_Present_PurchaseId",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Present");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Present",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Present_PresentId",
                        column: x => x.PresentId,
                        principalTable: "Present",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Present_CategoryId",
                table: "Present",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Present_WinnerId",
                table: "Present",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PresentId",
                table: "Ticket",
                column: "PresentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PurchaseId",
                table: "Ticket",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Present_Category_CategoryId",
                table: "Present",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present",
                column: "WinnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Present_Category_CategoryId",
                table: "Present");

            migrationBuilder.DropForeignKey(
                name: "FK_Present_User_WinnerId",
                table: "Present");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Present_CategoryId",
                table: "Present");

            migrationBuilder.DropIndex(
                name: "IX_Present_WinnerId",
                table: "Present");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Present");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Present",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}

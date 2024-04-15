using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddShowTimeToShowtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShowTime",
                table: "Showtimes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShowTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductShowtime",
                columns: table => new
                {
                    ShowtimesId = table.Column<int>(type: "int", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShowtime", x => new { x.ShowtimesId, x.productsId });
                    table.ForeignKey(
                        name: "FK_ProductShowtime_Products_productsId",
                        column: x => x.productsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShowtime_Showtimes_ShowtimesId",
                        column: x => x.ShowtimesId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShowtimeId",
                table: "Categories",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShowtime_productsId",
                table: "ProductShowtime",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Showtimes_ShowtimeId",
                table: "Categories",
                column: "ShowtimeId",
                principalTable: "Showtimes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Showtimes_ShowtimeId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "ProductShowtime");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShowtimeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShowTime",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "ShowTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Categories");
        }
    }
}

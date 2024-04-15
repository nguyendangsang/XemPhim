using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMovie.Migrations
{
    /// <inheritdoc />
    public partial class initialSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Seats_SeatId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Showtimes_ShowtimeId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ShowtimeId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SeatId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SeatShowtime",
                columns: table => new
                {
                    SeatsId = table.Column<int>(type: "int", nullable: false),
                    ShowtimesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatShowtime", x => new { x.SeatsId, x.ShowtimesId });
                    table.ForeignKey(
                        name: "FK_SeatShowtime_Seats_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatShowtime_Showtimes_ShowtimesId",
                        column: x => x.ShowtimesId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SeatId",
                table: "Categories",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatShowtime_ShowtimesId",
                table: "SeatShowtime",
                column: "ShowtimesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Seats_SeatId",
                table: "Categories",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Seats_SeatId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "SeatShowtime");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SeatId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ShowtimeId",
                table: "Seats",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SeatId",
                table: "Orders",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Seats_SeatId",
                table: "Orders",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Showtimes_ShowtimeId",
                table: "Seats",
                column: "ShowtimeId",
                principalTable: "Showtimes",
                principalColumn: "Id");
        }
    }
}

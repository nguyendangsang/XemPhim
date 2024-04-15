using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMovie.Migrations
{
    /// <inheritdoc />
    public partial class initialShowtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatShowtime");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "Showtimes",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Showtimes",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Showtimes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Showtimes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Showtimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Showtimes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_SeatId",
                table: "Showtimes",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Seats_SeatId",
                table: "Showtimes",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Seats_SeatId",
                table: "Showtimes");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_SeatId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Showtimes");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Showtimes",
                newName: "TheaterId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Showtimes",
                newName: "DateTime");

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
                name: "IX_SeatShowtime_ShowtimesId",
                table: "SeatShowtime",
                column: "ShowtimesId");
        }
    }
}

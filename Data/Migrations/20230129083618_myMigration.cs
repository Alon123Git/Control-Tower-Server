using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandEnum",
                columns: table => new
                {
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BrandEnu__BAB741D66AB6B66E", x => x.Brand);
                });

            migrationBuilder.CreateTable(
                name: "Logger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InAirplane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutAirplane = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Logger__3214EC07EF1569F3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    TerId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    WaitTime = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    isFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Terminal__6C716C1B65AC711F", x => x.TerId);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassengersCount = table.Column<int>(type: "int", nullable: true),
                    isLanding = table.Column<bool>(type: "bit", nullable: false),
                    TerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Flight__320C53801A7218DD", x => x.FlId);
                    table.ForeignKey(
                        name: "FK__Flight__TerId__3F466844",
                        column: x => x.TerId,
                        principalTable: "Terminal",
                        principalColumn: "TerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TerId",
                table: "Flight",
                column: "TerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandEnum");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Logger");

            migrationBuilder.DropTable(
                name: "Terminal");
        }
    }
}

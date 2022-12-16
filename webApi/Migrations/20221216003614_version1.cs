using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MushroomRooms",
                columns: table => new
                {
                    MusId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MushroomRooms", x => x.MusId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Humidity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2Level = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LightLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MushroomRoomMusId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasureId);
                    table.ForeignKey(
                        name: "FK_Measurements_MushroomRooms_MushroomRoomMusId",
                        column: x => x.MushroomRoomMusId,
                        principalTable: "MushroomRooms",
                        principalColumn: "MusId");
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    ThresholdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    muiMusId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureMinLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperatureMaxLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HumidityMinLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HumidityMaxLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2MinLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Co2MaxLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LightMinLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LightMaxLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.ThresholdId);
                    table.ForeignKey(
                        name: "FK_Thresholds_MushroomRooms_muiMusId",
                        column: x => x.muiMusId,
                        principalTable: "MushroomRooms",
                        principalColumn: "MusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MushroomRoomMusId",
                table: "Measurements",
                column: "MushroomRoomMusId");

            migrationBuilder.CreateIndex(
                name: "IX_Thresholds_muiMusId",
                table: "Thresholds",
                column: "muiMusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Thresholds");

            migrationBuilder.DropTable(
                name: "MushroomRooms");
        }
    }
}

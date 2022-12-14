using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MushroomRooms",
                columns: table => new
                {
                    MusId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Co2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LightLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MashroomRoomMusId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasureId);
                    table.ForeignKey(
                        name: "FK_Measurements_MushroomRooms_MashroomRoomMusId",
                        column: x => x.MashroomRoomMusId,
                        principalTable: "MushroomRooms",
                        principalColumn: "MusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MashroomRoomMusId",
                table: "Measurements",
                column: "MashroomRoomMusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "MushroomRooms");
        }
    }
}

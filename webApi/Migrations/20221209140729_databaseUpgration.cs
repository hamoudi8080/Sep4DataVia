using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class databaseUpgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Co2Max",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "Co2Min",
                table: "Measurements",
                newName: "Co2Level");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Co2Level",
                table: "Measurements",
                newName: "Co2Min");

            migrationBuilder.AddColumn<decimal>(
                name: "Co2Max",
                table: "Measurements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

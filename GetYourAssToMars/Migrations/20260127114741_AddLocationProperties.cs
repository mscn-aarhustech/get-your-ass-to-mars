using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetYourAssToMars.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "AirHumidity",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AirPressure",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AnnualPrecipitation",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BackgroundRadiation",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DayTemperature",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NightTemperature",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "Score",
                table: "Locations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UvIndex",
                table: "Locations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirHumidity",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AirPressure",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AnnualPrecipitation",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "BackgroundRadiation",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DayTemperature",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "NightTemperature",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UvIndex",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);
        }
    }
}

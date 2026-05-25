using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuleCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Rules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "RuleType",
                table: "Rules");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rules");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Rules",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "Rules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxValue",
                table: "Rules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinValue",
                table: "Rules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "Rules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RuleType",
                table: "Rules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

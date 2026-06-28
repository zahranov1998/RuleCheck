using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuleCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Rule_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rules",
                newName: "FieldName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rules",
                newName: "ErrorMessage");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "FieldName",
                table: "Rules",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "Rules",
                newName: "Description");
        }
    }
}

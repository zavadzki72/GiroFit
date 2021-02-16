using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.PostgreSQL.Migrations
{
    public partial class ResolveBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dta_start",
                table: "Train",
                newName: "is_finished");

            migrationBuilder.AddColumn<bool>(
                name: "is_locked",
                table: "Module",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_locked",
                table: "Module");

            migrationBuilder.RenameColumn(
                name: "is_finished",
                table: "Train",
                newName: "dta_start");
        }
    }
}

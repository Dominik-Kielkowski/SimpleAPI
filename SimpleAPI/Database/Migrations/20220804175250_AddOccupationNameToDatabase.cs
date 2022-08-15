using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class AddOccupationNameToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OccupationName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccupationName",
                table: "People");
        }
    }
}

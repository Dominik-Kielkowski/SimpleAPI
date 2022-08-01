using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class SeedOccupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "OccupationId", "OccupationName" },
                values: new object[] { 1, "Doctor" });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "OccupationId", "OccupationName" },
                values: new object[] { 2, "Firefighter" });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "OccupationId", "OccupationName" },
                values: new object[] { 3, "Policeman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "OccupationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "OccupationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "OccupationId",
                keyValue: 3);
        }
    }
}

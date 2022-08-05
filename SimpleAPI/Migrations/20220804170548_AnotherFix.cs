using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class AnotherFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_OccupationId",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_OccupationId",
                table: "People",
                column: "OccupationId",
                unique: true,
                filter: "[OccupationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_OccupationId",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_OccupationId",
                table: "People",
                column: "OccupationId");
        }
    }
}

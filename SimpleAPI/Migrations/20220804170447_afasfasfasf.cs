using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class afasfasfasf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_OccupationId",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_OccupationId",
                table: "People",
                column: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

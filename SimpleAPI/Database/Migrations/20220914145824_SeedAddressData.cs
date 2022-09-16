using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class SeedAddressData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Work" });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Temporary" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddressType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddressType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

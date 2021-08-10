using Microsoft.EntityFrameworkCore.Migrations;

namespace RatersOfTheLostBusiness.Migrations
{
    public partial class AddedBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "businesses",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State", "Type" },
                values: new object[] { 1, "375 Beale Street Suite 300", "San Franciso", "Twilio", "844-814-4627", "CA", "Software Service" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "businesses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

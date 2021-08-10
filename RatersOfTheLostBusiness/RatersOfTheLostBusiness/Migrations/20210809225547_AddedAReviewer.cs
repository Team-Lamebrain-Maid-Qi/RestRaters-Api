using Microsoft.EntityFrameworkCore.Migrations;

namespace RatersOfTheLostBusiness.Migrations
{
    public partial class AddedAReviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "reviewers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "reviewers",
                columns: new[] { "Id", "Email", "First", "Last", "PhoneNumber", "UserName" },
                values: new object[] { 1, "JS191@example.com", "John", "Stewart", "555-555-1221", "BestGreenLatern" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "reviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "reviewers");
        }
    }
}

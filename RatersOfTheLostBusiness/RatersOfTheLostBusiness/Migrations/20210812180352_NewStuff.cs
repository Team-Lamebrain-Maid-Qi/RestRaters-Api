using Microsoft.EntityFrameworkCore.Migrations;

namespace RatersOfTheLostBusiness.Migrations
{
    public partial class NewStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "businesses",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State", "Type" },
                values: new object[,]
                {
                    { 2, "400 N 140th Street", "NorthGate", "Margaritas", "844-814-4628", "WA", "Restaurant" },
                    { 3, "96 Main Street", "Greenville", "TjMinn", "844-814-4623", "WY", "Retail" },
                    { 4, "720 2nd Avenue", "Seattle", "GeekGeeks", "844-814-4621", "WA", "Tech Services" }
                });

            migrationBuilder.InsertData(
                table: "reviewers",
                columns: new[] { "Id", "Email", "First", "Last", "PhoneNumber", "UserName" },
                values: new object[] { 2, "SM191@example.com", "Stacy", "McGuire", "555-555-1220", "LittleMissStacy" });

            migrationBuilder.InsertData(
                table: "businessReviews",
                columns: new[] { "BusinessId", "ReviewerId", "Rating", "Review" },
                values: new object[] { 4, 1, 3m, "Way better service than those geeks at best buy" });

            migrationBuilder.InsertData(
                table: "businessReviews",
                columns: new[] { "BusinessId", "ReviewerId", "Rating", "Review" },
                values: new object[] { 3, 2, 2m, "The name says it all TjMaxx? more like TjMinn" });

            migrationBuilder.InsertData(
                table: "businessReviews",
                columns: new[] { "BusinessId", "ReviewerId", "Rating", "Review" },
                values: new object[] { 2, 2, 4m, "Margaritas so good you get 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "businessReviews",
                keyColumns: new[] { "BusinessId", "ReviewerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "businessReviews",
                keyColumns: new[] { "BusinessId", "ReviewerId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "businessReviews",
                keyColumns: new[] { "BusinessId", "ReviewerId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "businesses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "businesses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "businesses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "reviewers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

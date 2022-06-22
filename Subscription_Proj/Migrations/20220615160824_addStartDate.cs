using Microsoft.EntityFrameworkCore.Migrations;

namespace Subscription_Proj.Migrations
{
    public partial class addStartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    SubPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "StartDate", "SubPeriod", "SubscriptionName", "UnitPrice" },
                values: new object[] { 0, "05-01-2016", "Monthly", "Netflix", 9.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "StartDate", "SubPeriod", "SubscriptionName", "UnitPrice" },
                values: new object[] { 1, "07-29-2018", "Monthly", "Hulu", 12.99 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "StartDate", "SubPeriod", "SubscriptionName", "UnitPrice" },
                values: new object[] { 2, "01-01-2022", "Annualy", "PS PLUS", 120.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}

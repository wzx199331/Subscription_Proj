using Microsoft.EntityFrameworkCore.Migrations;

namespace Subscription_Proj.Migrations
{
    public partial class addDaysUsed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "daysUsed",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 0,
                columns: new[] { "StartDate", "daysUsed" },
                values: new object[] { "2016-05-01", "2236" });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1,
                columns: new[] { "StartDate", "daysUsed" },
                values: new object[] { "2018-07-29", "1417" });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2,
                columns: new[] { "StartDate", "category", "daysUsed" },
                values: new object[] { "2022-01-01", 1, "165" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "daysUsed",
                table: "Subscriptions");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 0,
                column: "StartDate",
                value: "05-01-2016");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1,
                column: "StartDate",
                value: "07-29-2018");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2,
                column: "StartDate",
                value: "01-01-2022");
        }
    }
}

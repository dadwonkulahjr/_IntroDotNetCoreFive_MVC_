using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreFive_MVC_Project.Migrations
{
    public partial class CompleteDbSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer ID", "Customer Agent", "Customer Email", "Customer Name" },
                values: new object[,]
                {
                    { 1, 3, "tom@t.com", "Tom" },
                    { 2, 1, "mike@m.com", "Mike" },
                    { 3, 4, "princess@p.com", "Princess" },
                    { 4, 2, "sharon@s.com", "Sharon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer ID",
                keyValue: 4);
        }
    }
}

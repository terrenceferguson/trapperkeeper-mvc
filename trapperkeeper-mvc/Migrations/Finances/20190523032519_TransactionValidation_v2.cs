using Microsoft.EntityFrameworkCore.Migrations;

namespace trapperkeeper_mvc.Migrations.Finances
{
    public partial class TransactionValidation_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Discover" },
                    { 2, "Arrival Plus" },
                    { 3, "Uber" },
                    { 4, "Chase" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Fixed" },
                    { 2, "Flexible" },
                    { 3, "Variable" },
                    { 4, "Debt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}

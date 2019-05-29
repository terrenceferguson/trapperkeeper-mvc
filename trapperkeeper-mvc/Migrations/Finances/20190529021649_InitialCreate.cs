using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trapperkeeper_mvc.Migrations.Finances
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    SubcategoryID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.SubcategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLedger",
                columns: table => new
                {
                    TransactionLedgerID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLedger", x => x.TransactionLedgerID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntry",
                columns: table => new
                {
                    TransactionEntryID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    SubcategoryID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    TransactionLedgerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntry", x => x.TransactionEntryID);
                    table.ForeignKey(
                        name: "FK_TransactionEntry_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionEntry_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionEntry_Subcategory_SubcategoryID",
                        column: x => x.SubcategoryID,
                        principalTable: "Subcategory",
                        principalColumn: "SubcategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionEntry_TransactionLedger_TransactionLedgerID",
                        column: x => x.TransactionLedgerID,
                        principalTable: "TransactionLedger",
                        principalColumn: "TransactionLedgerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "Description" },
                values: new object[,]
                {
                    { 1, "Discover" },
                    { 2, "Arrival Plus" },
                    { 3, "Uber" },
                    { 4, "Chase" },
                    { 5, "Ally Checking" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Description" },
                values: new object[,]
                {
                    { 1, "Fixed" },
                    { 2, "Flexible" },
                    { 3, "Variable" },
                    { 4, "Debt" }
                });

            migrationBuilder.InsertData(
                table: "Subcategory",
                columns: new[] { "SubcategoryID", "Description" },
                values: new object[,]
                {
                    { 12, "Fees" },
                    { 11, "Home" },
                    { 10, "Car" },
                    { 9, "Gifts" },
                    { 8, "Clothing" },
                    { 7, "Health" },
                    { 3, "Groceries" },
                    { 5, "Booze" },
                    { 4, "Gasoline" },
                    { 13, "Dog" },
                    { 2, "Restaurants" },
                    { 1, "Entertainment" },
                    { 6, "Professional" },
                    { 14, "Subscriptions" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_AccountID",
                table: "TransactionEntry",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_CategoryID",
                table: "TransactionEntry",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_SubcategoryID",
                table: "TransactionEntry",
                column: "SubcategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_TransactionLedgerID",
                table: "TransactionEntry",
                column: "TransactionLedgerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEntry");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "TransactionLedger");
        }
    }
}

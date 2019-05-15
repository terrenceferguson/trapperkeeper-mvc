using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trapperkeeper_mvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionLedgers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLedgers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    SubcategoryID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    TransactionLedgerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionEntries_TransactionLedgers_TransactionLedgerID",
                        column: x => x.TransactionLedgerID,
                        principalTable: "TransactionLedgers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntries_TransactionLedgerID",
                table: "TransactionEntries",
                column: "TransactionLedgerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEntries");

            migrationBuilder.DropTable(
                name: "TransactionLedgers");
        }
    }
}

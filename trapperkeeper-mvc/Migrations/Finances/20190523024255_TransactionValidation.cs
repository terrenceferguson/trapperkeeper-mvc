using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trapperkeeper_mvc.Migrations.Finances
{
    public partial class TransactionValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryID",
                table: "TransactionEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TransactionEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "TransactionEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.ID);
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

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntry_Account_AccountID",
                table: "TransactionEntry",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntry_Category_CategoryID",
                table: "TransactionEntry",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntry_Subcategory_SubcategoryID",
                table: "TransactionEntry",
                column: "SubcategoryID",
                principalTable: "Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntry_Account_AccountID",
                table: "TransactionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntry_Category_CategoryID",
                table: "TransactionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntry_Subcategory_SubcategoryID",
                table: "TransactionEntry");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionEntry_AccountID",
                table: "TransactionEntry");

            migrationBuilder.DropIndex(
                name: "IX_TransactionEntry_CategoryID",
                table: "TransactionEntry");

            migrationBuilder.DropIndex(
                name: "IX_TransactionEntry_SubcategoryID",
                table: "TransactionEntry");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryID",
                table: "TransactionEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TransactionEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "TransactionEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

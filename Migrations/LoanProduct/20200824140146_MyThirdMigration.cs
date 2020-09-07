using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EasyFinance.Migrations.LoanProduct
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    LogoImage = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    CreatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    InterestRate = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    FinancialMin = table.Column<string>(nullable: false),
                    FinancialMax = table.Column<string>(nullable: false),
                    TenureMin = table.Column<string>(nullable: false),
                    TenureMax = table.Column<string>(nullable: false),
                    AgeMin = table.Column<string>(nullable: false),
                    AgeMax = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<string>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanProduct_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanProduct_LoanTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanProduct_BankId",
                table: "LoanProduct",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanProduct_TypeId",
                table: "LoanProduct",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanProduct");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "LoanTypes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyStock.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock_Complete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticket = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock_Complete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Close = table.Column<float>(type: "real", nullable: false),
                    Low = table.Column<float>(type: "real", nullable: false),
                    High = table.Column<float>(type: "real", nullable: false),
                    Open = table.Column<float>(type: "real", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock_CompleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Stock_Complete_Stock_CompleteId",
                        column: x => x.Stock_CompleteId,
                        principalTable: "Stock_Complete",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    Available_funds = table.Column<double>(type: "float", nullable: false),
                    Total_balance = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioId);
                    table.ForeignKey(
                        name: "FK_Portfolios_Users_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockBounght",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    stockId = table.Column<int>(type: "int", nullable: false),
                    DateBought = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBounght", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockBounght_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId");
                    table.ForeignKey(
                        name: "FK_StockBounght_Stock_Complete_stockId",
                        column: x => x.stockId,
                        principalTable: "Stock_Complete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockBounght_PortfolioId",
                table: "StockBounght",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_StockBounght_stockId",
                table: "StockBounght",
                column: "stockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Stock_CompleteId",
                table: "Stocks",
                column: "Stock_CompleteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBounght");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Stock_Complete");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

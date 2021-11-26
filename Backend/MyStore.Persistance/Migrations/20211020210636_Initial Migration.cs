using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISOCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

           
            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Store",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.InsertData(
                schema: "Store",
                table: "Country",
                columns: new[] { "Id", "Culture", "ISOCode", "Name" },
                values: new object[,]
                {
                    { 1, "en-US", "USA", "United States" },
                    { 2, "en-CA", "CAN", "Canada" },
                    { 3, "en-GB", "GBR", "United Kingdom" },
                    { 4, "de-DE", "DEU", "Germany" },
                    { 5, "no-NO", "NOR", "Norway" },
                    { 6, "en-SG", "SGP", "Singapore" },
                    { 7, "en-AU", "AUS", "Australia" }
                });

            migrationBuilder.InsertData(
                schema: "Store",
                table: "Store",
                columns: new[] { "Id", "Code", "CountryId", "StoreName" },
                values: new object[,]
                {
                    { 1, "USA1", 1, "New York" },
                    { 2, "USA2", 1, "Los Angeles" },
                    { 3, "CAN1", 2, "Toronto Store" },
                    { 4, "CAN2", 2, "Vancour Store" },
                    { 5, "UK1", 3, "London Store" },
                    { 6, "GER1", 4, "Munich Store" },
                    { 7, "NOW1", 5, "Oslo Store" },
                    { 8, "SIN1", 6, "Singapore Store" },
                    { 9, "AUS1", 7, "Sedney Store" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderHeaderId",
                schema: "Sales",
                table: "OrderDetail",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                schema: "Sales",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_CustomerId",
                schema: "Sales",
                table: "OrderHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_StoreId",
                schema: "Sales",
                table: "OrderHeader",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                schema: "Store",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CountryId",
                schema: "Store",
                table: "Store",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Store");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Persistance.Migrations
{
    public partial class Createrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                schema: "Sales",
                table: "OrderDetail",
                column: "OrderHeaderId",
                principalSchema: "Sales",
                principalTable: "OrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                schema: "Sales",
                table: "OrderDetail",
                column: "ProductId",
                principalSchema: "Store",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Customer_CustomerId",
                schema: "Sales",
                table: "OrderHeader",
                column: "CustomerId",
                principalSchema: "Person",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_Store_StoreId",
                schema: "Sales",
                table: "OrderHeader",
                column: "StoreId",
                principalSchema: "Store",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_StoreId",
                schema: "Store",
                table: "Product",
                column: "StoreId",
                principalSchema: "Store",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Country_CountryId",
                schema: "Store",
                table: "Store",
                column: "CountryId",
                principalSchema: "Store",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                schema: "Sales",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                schema: "Sales",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Customer_CustomerId",
                schema: "Sales",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_Store_StoreId",
                schema: "Sales",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_StoreId",
                schema: "Store",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Country_CountryId",
                schema: "Store",
                table: "Store");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerceWebsite.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductVisibleDeleteFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visbile",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visbile",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Visbile",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Visbile",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Visbile",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 5 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 6 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 7 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 6, 5 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 8 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 9 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 10 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 9, 8 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 10, 1 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 1 },
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Visbile",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Visbile",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Visbile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Visbile",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Visbile",
                value: false);
        }
    }
}

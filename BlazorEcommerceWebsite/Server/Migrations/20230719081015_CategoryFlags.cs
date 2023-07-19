using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerceWebsite.Server.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visbile",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deleted", "Visbile" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Visbile",
                table: "Categories");
        }
    }
}

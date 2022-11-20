using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class CreateCategoryTableAndAddCategoryIdColumunToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 20, 9, 19, 42, 21, DateTimeKind.Utc).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 6, 52, 40, 982, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 20, 9, 19, 42, 23, DateTimeKind.Utc).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 18, 6, 52, 40, 983, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 20, 9, 19, 42, 23, DateTimeKind.Utc).AddTicks(2832))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 6, 52, 40, 982, DateTimeKind.Utc).AddTicks(8052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 20, 9, 19, 42, 21, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 18, 6, 52, 40, 983, DateTimeKind.Utc).AddTicks(9051),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 20, 9, 19, 42, 23, DateTimeKind.Utc).AddTicks(1370));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject2.Migrations
{
    public partial class CategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "in_prod",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "in_prod",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "in_prod",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "in_prod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_in_prod_CategoryId",
                table: "in_prod",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_in_prod_categories_CategoryId",
                table: "in_prod",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_in_prod_categories_CategoryId",
                table: "in_prod");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_in_prod_CategoryId",
                table: "in_prod");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "in_prod");

            migrationBuilder.InsertData(
                table: "in_prod",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Coke", 40 });

            migrationBuilder.InsertData(
                table: "in_prod",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Sprite", 50 });

            migrationBuilder.InsertData(
                table: "in_prod",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Sprite", 50 });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeCollections.DataAccess.Migrations
{
    public partial class manytomanywithjointable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories",
                table: "Recipes");

            //migrationBuilder.DropIndex(
            //    name: "IX_Recipes_CategoryId",
            //    table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.RecipeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

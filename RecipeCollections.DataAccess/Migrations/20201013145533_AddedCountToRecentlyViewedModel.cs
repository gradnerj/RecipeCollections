using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeCollections.DataAccess.Migrations
{
    public partial class AddedCountToRecentlyViewedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RecentlyViewed",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "RecentlyViewed");
        }
    }
}

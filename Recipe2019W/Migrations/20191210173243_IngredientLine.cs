using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe2019W.Migrations
{
    public partial class IngredientLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "IngredientLine",
                columns: table => new
                {
                    IngredientLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientID = table.Column<int>(nullable: true),
                    RecipeID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientLine", x => x.IngredientLineID);
                    table.ForeignKey(
                        name: "FK_IngredientLine_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientLine_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLine_IngredientID",
                table: "IngredientLine",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientLine_RecipeID",
                table: "IngredientLine",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientLine");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

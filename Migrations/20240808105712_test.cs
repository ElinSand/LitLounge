using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitLounge.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BookPosts_BookPostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory");

            migrationBuilder.DropTable(
                name: "BookPosts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookPostId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category_1",
                table: "Category_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Category_1_CategoryId",
                table: "Subcategory",
                column: "CategoryId",
                principalTable: "Category_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Category_1_CategoryId",
                table: "Subcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category_1",
                table: "Category_1");

            migrationBuilder.RenameTable(
                name: "Category_1",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPosts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookPostId",
                table: "Comments",
                column: "BookPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BookPosts_BookPostId",
                table: "Comments",
                column: "BookPostId",
                principalTable: "BookPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

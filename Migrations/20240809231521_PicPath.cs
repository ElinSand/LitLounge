using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitLounge.Migrations
{
    /// <inheritdoc />
    public partial class PicPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "AspNetUsers",
                newName: "ProfileImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImagePath",
                table: "AspNetUsers",
                newName: "ProfilePicture");
        }
    }
}

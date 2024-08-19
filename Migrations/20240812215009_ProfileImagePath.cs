using Microsoft.EntityFrameworkCore.Migrations;

//dateusing Microsoft.Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitLounge.Migrations
{
    /// <inheritdoc />
    public partial class ProfileImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Posts");
        }
    }
}

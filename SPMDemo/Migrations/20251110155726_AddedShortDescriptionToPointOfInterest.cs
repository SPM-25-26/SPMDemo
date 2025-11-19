using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPMDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddedShortDescriptionToPointOfInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "PointOfInterests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "PointOfInterests");
        }
    }
}

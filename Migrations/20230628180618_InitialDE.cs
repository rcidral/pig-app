using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pigapp.Migrations
{
    /// <inheritdoc />
    public partial class InitialDE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Cleans",
                newName: "RoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Cleans",
                newName: "RoomId");
        }
    }
}

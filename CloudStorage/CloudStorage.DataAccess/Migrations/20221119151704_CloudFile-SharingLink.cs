using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudStorage.DataAccess.Migrations
{
    public partial class CloudFileSharingLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                   name: "SharingLink",
                   table: "CloudFiles",
                   type: "nvarchar(max)",
                   nullable: true,
                   defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                    name: "SharingLink",
                    table: "CloudFiles");
        }
    }
}

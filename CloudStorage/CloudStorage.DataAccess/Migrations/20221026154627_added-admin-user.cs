using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudStorage.DataAccess.Migrations
{
    public partial class addedadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a0955e3-a6d3-411b-afab-4cd4eb1a3638", 0, "4bbef09b-5cc3-4d03-9415-af7e868f8c05", "admin@admin.com", false, false, null, null, null, "AKW8UTNUqktMXain78dZn5KZnwzbDUdM1JgWwJshlHDaV5Ni25Dhq1rrbuWz+C5U0A==", null, false, null, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a0955e3-a6d3-411b-afab-4cd4eb1a3638");
        }
    }
}

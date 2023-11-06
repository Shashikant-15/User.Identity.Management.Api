using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Identity.Management.Api.Migrations
{
    public partial class RolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5788e94e-7c28-4c73-967b-2a359590584c", "3", "HR", "HR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75b54f86-33b2-453f-864d-dc8d772e665e", "1", "Shashi", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0045685-1b46-451d-816b-c24296d67de1", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5788e94e-7c28-4c73-967b-2a359590584c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75b54f86-33b2-453f-864d-dc8d772e665e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0045685-1b46-451d-816b-c24296d67de1");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FStore.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e86fd9b-5dc6-4a22-b869-3bf62814e4d5", null, "Seller", "SELLER" },
                    { "45781fcd-f4ba-426e-b0e8-641ffa2051bd", null, "Manager", "MANAGER" },
                    { "d4113ae1-bd08-4ff6-9f44-af08b1f5d603", null, "Administrator", "ADMINISTRATOR" },
                    { "e1aeb80e-fe63-40a3-8074-73e7fcca2428", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e86fd9b-5dc6-4a22-b869-3bf62814e4d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45781fcd-f4ba-426e-b0e8-641ffa2051bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4113ae1-bd08-4ff6-9f44-af08b1f5d603");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1aeb80e-fe63-40a3-8074-73e7fcca2428");
        }
    }
}

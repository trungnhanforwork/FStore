using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FStore.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "428f6fa2-52e0-4a3b-a1a4-f0fcfd118f65", null, "User", "USER" },
                    { "5b26ff40-2cdb-4f07-93b8-c6da2fd7b7f9", null, "Seller", "SELLER" },
                    { "a1a6e318-ae6a-46e9-b58e-e8b85a75121a", null, "Manager", "MANAGER" },
                    { "fda8fa09-f7f5-47f9-9a9e-2a8e859d0c79", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "428f6fa2-52e0-4a3b-a1a4-f0fcfd118f65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b26ff40-2cdb-4f07-93b8-c6da2fd7b7f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a6e318-ae6a-46e9-b58e-e8b85a75121a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda8fa09-f7f5-47f9-9a9e-2a8e859d0c79");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}

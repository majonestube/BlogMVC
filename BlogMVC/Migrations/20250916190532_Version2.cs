using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMVC.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "default-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "87a2c10c-b743-4910-b78f-ac3a4dcf082b", "AQAAAAIAAYagAAAAEMrs03peJytHfKaq2r+xReZyurIdrrME8HgkjjQ8L52BYjc0uMNjllje1AgEvwrlHw==", "default@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "donkey-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "42b86892-1317-4f1c-b855-e0f9a32e46be", "AQAAAAIAAYagAAAAEGVQONu+vue6mixDmXMW18PJk5h+iv8Jok1UWEpuZDggKL7ZoQJOASP3oow6VEQz6A==", "donkey@example.com" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 21, 5, 31, 154, DateTimeKind.Local).AddTicks(3499));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "default-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "0a235a10-b482-442c-83f5-4e329a5e85f8", "AQAAAAIAAYagAAAAEH5X8IEVAIDSvsC1jqyYw2R7tPiUQfsom8AcrbNPDfx+ZY9wpIWjFBkomdHqKee9OQ==", "default-user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "donkey-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "c620419a-9c4b-4e5a-97e6-a56e15dddf85", "AQAAAAIAAYagAAAAEC28U14W3/SDl0/Lnfv1TUhiyGylbuOxp08zCEoclI+YB8S45YEsqNfxd3NhLCA8aw==", "theDonkey" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Modified",
                value: new DateTime(2025, 9, 16, 18, 5, 54, 316, DateTimeKind.Local).AddTicks(3787));
        }
    }
}

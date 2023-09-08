using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Julian Sosa" },
                    { 2, "Maria Perez" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CustomerId", "HashedPin", "Number", "Status" },
                values: new object[,]
                {
                    { 1, 1, new byte[] { 21, 5, 145, 210, 119, 184, 252, 70, 155, 161, 160, 130, 108, 161, 9, 131, 254, 131, 35, 174, 69, 36, 94, 205, 226, 222, 205, 217, 210, 1, 77, 110, 19, 6, 85, 138, 126, 101, 107, 81, 94, 76, 57, 134, 246, 234, 171, 114, 18, 6, 69, 136, 0, 66, 36, 63, 104, 9, 197, 3, 59, 141, 109, 220 }, 12345678, "Enabled" },
                    { 2, 2, new byte[] { 79, 77, 218, 189, 94, 17, 98, 162, 228, 116, 28, 8, 238, 223, 55, 65, 107, 254, 2, 149, 93, 240, 46, 176, 127, 217, 2, 29, 235, 152, 49, 190, 117, 165, 111, 218, 18, 131, 232, 9, 183, 15, 198, 106, 57, 160, 151, 67, 171, 203, 23, 141, 144, 192, 68, 192, 169, 104, 99, 61, 111, 40, 180, 225 }, 87654321, "Enabled" },
                    { 3, 1, new byte[] { 255, 176, 18, 252, 82, 70, 255, 171, 145, 37, 103, 160, 229, 206, 222, 188, 48, 31, 213, 65, 67, 142, 48, 213, 82, 1, 191, 115, 202, 169, 57, 98, 229, 243, 2, 157, 195, 182, 125, 183, 40, 90, 72, 117, 120, 193, 164, 184, 60, 206, 153, 104, 139, 179, 95, 157, 105, 98, 231, 152, 92, 110, 194, 215 }, 15694947, "Enabled" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CardId", "LastWithdrawalDate", "Number" },
                values: new object[,]
                {
                    { 1, 500000m, 1, new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479), 123456 },
                    { 2, 200000m, 2, new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479), 456789 },
                    { 3, 0m, 3, new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479), 555555 }
                });

            migrationBuilder.InsertData(
                table: "CardLoginAttempts",
                columns: new[] { "Id", "CardId", "FailedAttempts" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 },
                    { 3, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "AccountId", "Amount", "Balance", "Date", "OperationType" },
                values: new object[,]
                {
                    { 1, 1, 50000m, 50000m, new DateTime(2023, 9, 8, 19, 47, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 2, 1, 50000m, 100000m, new DateTime(2023, 9, 8, 19, 57, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 3, 1, 50000m, 150000m, new DateTime(2023, 9, 8, 19, 58, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 4, 1, 50000m, 200000m, new DateTime(2023, 9, 8, 19, 59, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 5, 1, 50000m, 250000m, new DateTime(2023, 9, 8, 20, 0, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 6, 1, 50000m, 300000m, new DateTime(2023, 9, 8, 20, 1, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 7, 1, 50000m, 350000m, new DateTime(2023, 9, 8, 20, 2, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 8, 1, 50000m, 400000m, new DateTime(2023, 9, 8, 20, 3, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 9, 1, 50000m, 450000m, new DateTime(2023, 9, 8, 20, 4, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 10, 1, 25000m, 475000m, new DateTime(2023, 9, 8, 20, 5, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 11, 1, 25000m, 500000m, new DateTime(2023, 9, 8, 20, 6, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" },
                    { 12, 2, 200000m, 200000m, new DateTime(2023, 9, 8, 20, 7, 50, 70, DateTimeKind.Utc).AddTicks(5479), "Deposit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CardLoginAttempts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CardLoginAttempts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CardLoginAttempts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

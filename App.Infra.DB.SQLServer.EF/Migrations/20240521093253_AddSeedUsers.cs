using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Expert", "EXPERT" },
                    { 3, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "ConcurrencyStamp", "CustomerId", "Email", "EmailConfirmed", "ExpertId", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "30766804-1855-4f1e-98b2-c7bd7578b1b3", null, "navid@gmail.com", false, null, "Navid Jafarzdeh", false, null, "NAVID@GMAIL.COM", "NAVID@GMAIL.COM", "AQAAAAIAAYagAAAAEJ6DFIXyiNi9R8yZGTJMxUJHb0tsyu3y3fODkk5PMI2nWOJOZVI+wZMDYY4l6ZGmiw==", "1234567890", false, "067ba635-0517-46a0-bfbd-a0902e135f48", false, "navid@gmail.com" },
                    { 2, 0, null, "1604afcc-7a74-4e23-a544-d26b5fc2c9db", null, "Ali@gmail.com", false, 2, "Ali Karimi", false, null, "ALI@GMAIL.COM", "ALI@GMAIL.COM", "AQAAAAIAAYagAAAAEPCn6sNl3hKmBylcBN2B6NqehSNcSOlKSpPh3FM+QiJMx8tt8ra9rEQg5xofV7l9MA==", "09377507920", false, "94059534-f46f-4f8e-ab5c-3c6325c86339", false, "Ali@gmail.com" },
                    { 3, 0, null, "4ba34a4b-21ff-4429-8d26-9eb40cc72a4a", null, "Sahar@gmail.com", false, 3, "Sahar Akbari", false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAEHATx187AK8uHJuV4ehj+DzaWv48pEzdnSNyQGLh96BYqXeyeVGd1fAqAXcaEMuZSA==", "09377507920", false, "1cbf4f15-ab1e-421a-9d55-84a083ceb3cb", false, "Sahar@gmail.com" },
                    { 4, 0, null, "2f2fcf0f-0426-455c-b745-8de1c92df8c7", 4, "Maryam@gmail.com", false, null, "Maryam Asadi", false, null, "MARYAM@GMAIL.COM", "MARYAM@GMAIL.COM", "AQAAAAIAAYagAAAAELBJyWP62bpksyjpSChXkVLeX6eqGRVI8c0wHt2IX8huAwAlSZepnJTedGBvkHJzZA==", "09377507920", false, "393b7065-eebf-443b-b1af-ecbb53806345", false, "Maryam@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 13, 2, 52, 507, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 539, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(693));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 21, 12, 59, 17, 540, DateTimeKind.Local).AddTicks(719));
        }
    }
}

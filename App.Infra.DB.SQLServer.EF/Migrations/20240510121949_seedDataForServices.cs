using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class seedDataForServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "خانه تکانی");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "دیجیتال و نرم افزار");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "PictureLocation", "Title" },
                values: new object[] { 6, null, "خدمان اداری" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "ImageSrc", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2558), null, false, "بنایی و ساختمان" },
                    { 2, 1, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2559), null, false, "گچ کاری کاری" },
                    { 3, 1, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2561), null, false, "شیشه بری" },
                    { 4, 2, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2562), null, false, "کولر آبی" },
                    { 5, 2, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2563), null, false, "کولر گازی" },
                    { 6, 2, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2564), null, false, "آب گرم کن" },
                    { 7, 2, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2566), null, false, "لوله باز کنی" },
                    { 8, 2, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2567), null, false, "برق کاری ساختمان" },
                    { 9, 3, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2568), null, false, "تعویض روغن" },
                    { 10, 3, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2569), null, false, "نقاشی و صافکاری" },
                    { 11, 3, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2570), null, false, "تعمیر خودرو" },
                    { 12, 4, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2571), null, false, "اسباب کشی" },
                    { 13, 4, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2573), null, false, "حمل بار جزعی" },
                    { 14, 5, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2574), null, false, "یخچال و فریزر" },
                    { 15, 5, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2575), null, false, "سینما خانگی" },
                    { 16, 5, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2576), null, false, "ماشین لباس شویی" },
                    { 20, 7, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2581), null, false, "نظافت منزل" },
                    { 21, 7, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2582), null, false, "نظافت اداره و شرکت" },
                    { 22, 8, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2583), null, false, "لپ تاپ و نوت بوک" },
                    { 23, 8, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2584), null, false, "موبایل و تبلت" },
                    { 24, 8, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2585), null, false, "ارتقای سخت افزاری" },
                    { 25, 8, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2586), null, false, "شبکه کامپیوتری" },
                    { 17, 6, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2577), null, false, "فوتو کپی" },
                    { 18, 6, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2578), null, false, "فکس" },
                    { 19, 6, new DateTime(2024, 5, 10, 15, 49, 48, 507, DateTimeKind.Local).AddTicks(2579), null, false, "پارتیشن" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "خدمان اداری");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "بهداشت و نظافت");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "PictureLocation", "Title" },
                values: new object[] { 9, null, "دیجیتال و نرم افزار" });
        }
    }
}

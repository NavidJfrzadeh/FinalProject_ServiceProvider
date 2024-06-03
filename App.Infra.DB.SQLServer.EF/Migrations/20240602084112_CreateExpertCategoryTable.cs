using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class CreateExpertCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFor",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptBid",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishedAt",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bids",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "CategoryExpert",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ExpertsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryExpert", x => new { x.CategoriesId, x.ExpertsId });
                    table.ForeignKey(
                        name: "FK_CategoryExpert_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryExpert_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bddd934-0264-4488-86a9-0ffa985d7563", "AQAAAAIAAYagAAAAEFXLAggNfVEG8HNnF325gsOULGfYxXz7ihX46E0KYXr2TE6iWADXmHOP9UVVzw1VBA==", "aa94a9a1-f9ea-4c04-ae24-84da6b4877af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e8be020-11c3-4acd-b15a-26ac19643d75", "AQAAAAIAAYagAAAAENnVnBm5kezKMhtCnN44Nk5CESmkFSo3r61zxae3mzF1xbCbV/O4KqewLLBKydPjcg==", "29b2352f-1ac8-4bd7-8d78-166af86c853b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "500ff464-ef49-4d8a-87fc-39f3b254bc69", "AQAAAAIAAYagAAAAEAuBpEH1L0iSpyr4Duabkcr+sbwXMC3FWpTxBHSGzc+4KOrMs6J1xSZcQ0j17vgCbA==", "02876f15-8465-4b19-be3b-3abf62ea9779" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e1c2371-5528-4e72-acb3-4ff4c84bb163", "AQAAAAIAAYagAAAAELnLTwD8cLFkJzKYOlU9/0Ik4zht8bgTc7RtP6JSYy80mYrFtIRJ+DcEYLsP7Q+uGQ==", "a1ad284c-fe85-4ca9-a4e9-2c8345384540" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 685, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 2, 12, 11, 10, 686, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExpert_ExpertsId",
                table: "CategoryExpert",
                column: "ExpertsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryExpert");

            migrationBuilder.DropColumn(
                name: "DateFor",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsAcceptBid",
                table: "Requests");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FinishedAt",
                table: "Bids",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bids",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "960707ba-d348-425e-90c2-05b2f039026f", "AQAAAAIAAYagAAAAEBQaLeOttbrvYiXOsla1LN/HwW7XYrtAB0kn8sruCefCgdqGyOwngzWlUfY7IKnEhg==", "3f033ca1-e9ad-4958-a2e4-df3b3dc785c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9b29e80-874f-4d64-9dbf-b7f360ee8e2b", "AQAAAAIAAYagAAAAEAwwsOCWf/CgNaTgtnFOumEKxZsh3Hisjr49QnC/JqdTJoj3snjFj99nQ+RdEL2H1w==", "0a48e850-c883-493a-851a-2292e7076b21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fd3dfcd-be3f-4f7a-a719-9a9e0a1b3f9c", "AQAAAAIAAYagAAAAEFO/CkTuxp4RjGVRFyVBnIYR1piNtPrWvKIncKpgzIss783Difvz6DZ3KS74KvVUlg==", "624ea457-1639-4eda-852f-bc0fe1d18bcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99adf9ea-385c-4083-85ca-970bc5f1deeb", "AQAAAAIAAYagAAAAEO/2xJItF1JC6ibL1gJytftbf4OHy/pTK7wDIrDf7edY0QgMgCP0i2MBIIYGJTipfg==", "cc3dc07c-1df2-4c2b-bd3f-cffc862f6c5c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 22, 23, 34, 0, 595, DateTimeKind.Local).AddTicks(6228));
        }
    }
}

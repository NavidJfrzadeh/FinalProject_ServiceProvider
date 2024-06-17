using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRequestCommentOneToManyRequestExpert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptedExpertId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e4e57b9-397f-4cd1-9761-5bc41b067c33", "AQAAAAIAAYagAAAAEDF5uCDIB9uMHyolAE/8n5pdSxJeMBouQcbGp2lC7MVR0Vyr8CToBh3l1bzwMb1lLw==", "068d574d-bd59-42c7-b7b8-e47a1150db75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ea17a3f-d4a3-40a7-b211-7a7872847cf7", "AQAAAAIAAYagAAAAEBG5K85VpWKrh29Egvz/O3BIBq5qJjqc7PY55eXYK6ZgdSyAYlYwPgbW1Sacrf0UYg==", "db90e8d9-1900-49eb-8ef8-0b08f55ac765" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a04906a-1114-47fd-b911-adaa448d28f3", "AQAAAAIAAYagAAAAEDqrYELdqw/hYksKnotH3jC62nD0BB3+TboFuWk4I/0ZcV2fMte/3Tx76jGbYf7yWg==", "91aed85e-bd04-41bd-b5c0-c05b0f9c80e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61635870-4cf2-4086-82ad-14230ff79ed2", "AQAAAAIAAYagAAAAEKasZ9HdBBdE7ibNQ7fpFrQuxPx1oYPCfjOyA21Eh7UQWPKOndxIjqwaHC18O1Rtxg==", "082874ba-c002-414d-a822-f9eabc2bfbab" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 443, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 17, 19, 55, 52, 444, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AcceptedExpertId",
                table: "Requests",
                column: "AcceptedExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CommentId",
                table: "Requests",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Comments_CommentId",
                table: "Requests",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Experts_AcceptedExpertId",
                table: "Requests",
                column: "AcceptedExpertId",
                principalTable: "Experts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Comments_CommentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Experts_AcceptedExpertId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AcceptedExpertId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CommentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AcceptedExpertId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptBid",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class AddVillaNumberDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "villaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(nullable: false),
                    SpecialDetails = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villaNumber", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 106, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 16, 54, 26, 112, DateTimeKind.Local).AddTicks(6180));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "villaNumber");

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 10, 11, 43, 17, 778, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 10, 11, 43, 17, 781, DateTimeKind.Local).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 10, 11, 43, 17, 781, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 10, 11, 43, 17, 781, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "VillaDb",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 10, 11, 43, 17, 781, DateTimeKind.Local).AddTicks(8133));
        }
    }
}

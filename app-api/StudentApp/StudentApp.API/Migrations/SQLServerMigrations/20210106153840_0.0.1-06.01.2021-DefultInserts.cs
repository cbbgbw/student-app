using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00106012021DefultInserts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey" },
                values: new object[,]
                {
                    { new Guid("40cc05c5-70c4-4766-b0a2-e1e47d618d2b"), "Odpowiedź ustna", new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), 1, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("47d77b7f-7e82-4564-828b-c97eb4d1f7e6"), "Kartkówka", new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), 1, new Guid("00000000-0000-0000-0000-000000000022") }
                });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.InsertData(
                table: "DefinitionGroup",
                columns: new[] { "DefinitionGroupKey", "CreateTime", "Description", "GroupName", "ModifyTime" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), "Typ projektu", "PROJECT_TYPES", new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), "Projekt" });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), "Egzamin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("40cc05c5-70c4-4766-b0a2-e1e47d618d2b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("47d77b7f-7e82-4564-828b-c97eb4d1f7e6"));

            migrationBuilder.DeleteData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });
        }
    }
}

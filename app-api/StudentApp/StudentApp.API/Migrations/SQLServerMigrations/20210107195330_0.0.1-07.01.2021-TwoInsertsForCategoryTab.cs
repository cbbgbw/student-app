using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00107012021TwoInsertsForCategoryTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("40cc05c5-70c4-4766-b0a2-e1e47d618d2b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("47d77b7f-7e82-4564-828b-c97eb4d1f7e6"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey" },
                values: new object[,]
                {
                    { new Guid("8b79b0a3-83ba-4ca7-bdce-3aa035f224a6"), "Odpowiedź ustna", new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), 1, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("a695f015-326f-41b2-ae5a-c021cb8cc49f"), "Kartkówka", new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), 2, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("f2e2285b-faeb-4d09-88a3-390af93534e4"), "Projekt zespołowy", new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), 1, new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("3eccbed0-4883-4e82-a1fe-832ffa0b52ee"), "Projekt zaliczeniowy", new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), 2, new Guid("00000000-0000-0000-0000-000000000012") }
                });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 1, 7, 20, 53, 30, 84, DateTimeKind.Local).AddTicks(6994) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("3eccbed0-4883-4e82-a1fe-832ffa0b52ee"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("8b79b0a3-83ba-4ca7-bdce-3aa035f224a6"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("a695f015-326f-41b2-ae5a-c021cb8cc49f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("f2e2285b-faeb-4d09-88a3-390af93534e4"));

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
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078), new DateTime(2021, 1, 6, 16, 38, 39, 819, DateTimeKind.Local).AddTicks(4078) });

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
        }
    }
}

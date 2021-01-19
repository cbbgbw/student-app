using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00117012021UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("27fd71bf-f9e1-4293-a494-be76b477c706"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9969b359-b888-4d07-8e0a-f79234f58adb"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9a684681-ffac-42e6-97a5-c07fb18e2a32"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("c94de30c-a03a-4432-91a1-310ace86050a"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("5331b1c1-3bdb-4a06-8150-c3eb56a5364f"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("9f7116df-ae43-49e9-9144-99a299e38fd5"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("c7effbb1-77c8-4b99-824e-d3dcd985c8c8"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("bdfc4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("ce1c4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new byte[] { 175, 72, 199, 212, 95, 190, 179, 144, 148, 91, 27, 117, 229, 181, 239, 182, 253, 225, 247, 44, 15, 199, 139, 177, 34, 52, 213, 40, 41, 230, 34, 193, 252, 240, 160, 40, 63, 35, 165, 203, 60, 49, 90, 13, 203, 77, 218, 167, 196, 66, 60, 132, 48, 179, 251, 148, 184, 28, 131, 188, 108, 147, 204, 214 }, new byte[] { 153, 70, 102, 152, 173, 143, 158, 191, 178, 40, 16, 252, 11, 181, 240, 106, 203, 100, 153, 217, 215, 186, 200, 67, 92, 188, 251, 20, 149, 52, 67, 0, 107, 218, 87, 156, 246, 172, 88, 154, 234, 204, 146, 208, 226, 228, 66, 255, 183, 1, 167, 170, 46, 210, 157, 31, 123, 57, 150, 56, 18, 243, 156, 61, 84, 38, 6, 131, 155, 151, 36, 18, 200, 55, 167, 9, 132, 92, 52, 120, 31, 125, 106, 246, 195, 49, 148, 122, 4, 33, 197, 199, 198, 114, 144, 97, 141, 109, 176, 21, 202, 34, 171, 209, 229, 104, 192, 188, 209, 201, 105, 128, 129, 91, 161, 229, 46, 18, 165, 177, 105, 129, 193, 190, 48, 214, 72, 126 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new DateTime(2021, 1, 17, 21, 48, 38, 183, DateTimeKind.Local).AddTicks(7588), new byte[] { 175, 72, 199, 212, 95, 190, 179, 144, 148, 91, 27, 117, 229, 181, 239, 182, 253, 225, 247, 44, 15, 199, 139, 177, 34, 52, 213, 40, 41, 230, 34, 193, 252, 240, 160, 40, 63, 35, 165, 203, 60, 49, 90, 13, 203, 77, 218, 167, 196, 66, 60, 132, 48, 179, 251, 148, 184, 28, 131, 188, 108, 147, 204, 214 }, new byte[] { 153, 70, 102, 152, 173, 143, 158, 191, 178, 40, 16, 252, 11, 181, 240, 106, 203, 100, 153, 217, 215, 186, 200, 67, 92, 188, 251, 20, 149, 52, 67, 0, 107, 218, 87, 156, 246, 172, 88, 154, 234, 204, 146, 208, 226, 228, 66, 255, 183, 1, 167, 170, 46, 210, 157, 31, 123, 57, 150, 56, 18, 243, 156, 61, 84, 38, 6, 131, 155, 151, 36, 18, 200, 55, 167, 9, 132, 92, 52, 120, 31, 125, 106, 246, 195, 49, 148, 122, 4, 33, 197, 199, 198, 114, 144, 97, 141, 109, 176, 21, 202, 34, 171, 209, 229, 104, 192, 188, 209, 201, 105, 128, 129, 91, 161, 229, 46, 18, 165, 177, 105, 129, 193, 190, 48, 214, 72, 126 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("27fd71bf-f9e1-4293-a494-be76b477c706"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9969b359-b888-4d07-8e0a-f79234f58adb"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9a684681-ffac-42e6-97a5-c07fb18e2a32"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("c94de30c-a03a-4432-91a1-310ace86050a"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("5331b1c1-3bdb-4a06-8150-c3eb56a5364f"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("9f7116df-ae43-49e9-9144-99a299e38fd5"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("c7effbb1-77c8-4b99-824e-d3dcd985c8c8"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("bdfc4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("ce1c4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime", "Password" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), "cyberbug2021" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime", "Password" },
                values: new object[] { new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), new DateTime(2021, 1, 16, 18, 44, 37, 343, DateTimeKind.Local).AddTicks(8136), "cyberbug2021" });
        }
    }
}

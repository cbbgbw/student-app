using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00225012021CategoryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectStatusKey",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000001"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserKey",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("27fd71bf-f9e1-4293-a494-be76b477c706"),
                columns: new[] { "CreateTime", "ModifyTime", "UserKey" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9969b359-b888-4d07-8e0a-f79234f58adb"),
                columns: new[] { "CreateTime", "ModifyTime", "UserKey" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9a684681-ffac-42e6-97a5-c07fb18e2a32"),
                columns: new[] { "CreateTime", "ModifyTime", "UserKey" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("c94de30c-a03a-4432-91a1-310ace86050a"),
                columns: new[] { "CreateTime", "ModifyTime", "UserKey" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("5331b1c1-3bdb-4a06-8150-c3eb56a5364f"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("9f7116df-ae43-49e9-9144-99a299e38fd5"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("c7effbb1-77c8-4b99-824e-d3dcd985c8c8"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("bdfc4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("ce1c4999-ea15-4aef-816f-df1d0ab501ee"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ModifyTime", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 119, 88, 220, 138, 39, 99, 23, 96, 153, 60, 102, 53, 102, 243, 104, 85, 107, 203, 136, 231, 182, 54, 91, 51, 223, 120, 98, 244, 65, 132, 57, 10, 244, 60, 245, 201, 93, 235, 141, 34, 6, 101, 252, 229, 105, 136, 66, 238, 141, 91, 206, 140, 175, 154, 61, 133, 160, 253, 78, 27, 18, 186, 224, 134 }, new byte[] { 188, 147, 189, 179, 90, 108, 22, 221, 182, 34, 73, 200, 253, 163, 183, 246, 88, 68, 52, 17, 5, 118, 12, 98, 133, 190, 245, 144, 13, 209, 81, 111, 93, 71, 179, 207, 188, 133, 74, 123, 116, 91, 114, 242, 102, 111, 50, 2, 34, 76, 31, 255, 60, 105, 136, 143, 104, 186, 90, 8, 165, 53, 221, 130, 33, 146, 166, 101, 38, 148, 81, 157, 148, 212, 49, 193, 21, 19, 15, 190, 79, 27, 62, 195, 144, 241, 113, 199, 164, 36, 162, 220, 217, 206, 130, 126, 179, 32, 98, 176, 181, 65, 234, 142, 46, 88, 79, 238, 111, 33, 216, 164, 3, 21, 230, 55, 66, 34, 70, 88, 77, 169, 23, 67, 54, 4, 211, 38 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreateTime", "ModifyTime", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 119, 88, 220, 138, 39, 99, 23, 96, 153, 60, 102, 53, 102, 243, 104, 85, 107, 203, 136, 231, 182, 54, 91, 51, 223, 120, 98, 244, 65, 132, 57, 10, 244, 60, 245, 201, 93, 235, 141, 34, 6, 101, 252, 229, 105, 136, 66, 238, 141, 91, 206, 140, 175, 154, 61, 133, 160, 253, 78, 27, 18, 186, 224, 134 }, new byte[] { 188, 147, 189, 179, 90, 108, 22, 221, 182, 34, 73, 200, 253, 163, 183, 246, 88, 68, 52, 17, 5, 118, 12, 98, 133, 190, 245, 144, 13, 209, 81, 111, 93, 71, 179, 207, 188, 133, 74, 123, 116, 91, 114, 242, 102, 111, 50, 2, 34, 76, 31, 255, 60, 105, 136, 143, 104, 186, 90, 8, 165, 53, 221, 130, 33, 146, 166, 101, 38, 148, 81, 157, 148, 212, 49, 193, 21, 19, 15, 190, 79, 27, 62, 195, 144, 241, 113, 199, 164, 36, 162, 220, 217, 206, 130, 126, 179, 32, 98, 176, 181, 65, 234, 142, 46, 88, 79, 238, 111, 33, 216, 164, 3, 21, 230, 55, 66, 34, 70, 88, 77, 169, 23, 67, 54, 4, 211, 38 } });

            migrationBuilder.CreateIndex(
                name: "IX_Category_UserKey",
                table: "Category",
                column: "UserKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UserKey",
                table: "Category",
                column: "UserKey",
                principalTable: "User",
                principalColumn: "UserKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UserKey",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_UserKey",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "Category");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectStatusKey",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000001"));

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
    }
}

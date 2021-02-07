using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00206022021InsertEmptyGuids_CategoryDataChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("27fd71bf-f9e1-4293-a494-be76b477c706"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9969b359-b888-4d07-8e0a-f79234f58adb"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("9a684681-ffac-42e6-97a5-c07fb18e2a32"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("c94de30c-a03a-4432-91a1-310ace86050a"));

            migrationBuilder.InsertData(
                table: "DefinitionGroup",
                columns: new[] { "DefinitionGroupKey", "CreateTime", "Description", "GroupName", "ModifyTime" },
                values: new object[] { new Guid("00000000-0000-0000-ffff-ffffffffffff"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 6, 81, 65, 91, 168, 254, 104, 72, 191, 225, 114, 101, 84, 34, 232, 133, 241, 217, 205, 201, 1, 138, 242, 57, 176, 100, 98, 10, 175, 160, 131, 21, 114, 140, 24, 64, 76, 67, 155, 3, 43, 53, 94, 6, 115, 217, 167, 154, 211, 145, 70, 97, 120, 205, 67, 22, 68, 109, 206, 7, 85, 94, 53, 137 }, new byte[] { 73, 197, 226, 246, 109, 249, 107, 141, 22, 196, 140, 219, 232, 0, 163, 117, 172, 169, 31, 228, 66, 6, 211, 44, 215, 204, 27, 31, 119, 22, 51, 246, 246, 113, 145, 226, 179, 81, 222, 29, 202, 128, 189, 86, 107, 118, 244, 171, 10, 174, 185, 178, 144, 196, 52, 197, 233, 177, 66, 140, 9, 240, 234, 19, 246, 225, 96, 230, 32, 196, 3, 133, 108, 130, 146, 200, 247, 162, 92, 190, 70, 105, 174, 128, 25, 135, 50, 70, 37, 13, 65, 72, 242, 17, 199, 202, 94, 146, 67, 99, 9, 202, 31, 48, 91, 105, 223, 75, 86, 145, 172, 163, 109, 147, 80, 72, 108, 26, 185, 199, 73, 183, 57, 234, 158, 5, 152, 148 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 6, 81, 65, 91, 168, 254, 104, 72, 191, 225, 114, 101, 84, 34, 232, 133, 241, 217, 205, 201, 1, 138, 242, 57, 176, 100, 98, 10, 175, 160, 131, 21, 114, 140, 24, 64, 76, 67, 155, 3, 43, 53, 94, 6, 115, 217, 167, 154, 211, 145, 70, 97, 120, 205, 67, 22, 68, 109, 206, 7, 85, 94, 53, 137 }, new byte[] { 73, 197, 226, 246, 109, 249, 107, 141, 22, 196, 140, 219, 232, 0, 163, 117, 172, 169, 31, 228, 66, 6, 211, 44, 215, 204, 27, 31, 119, 22, 51, 246, 246, 113, 145, 226, 179, 81, 222, 29, 202, 128, 189, 86, 107, 118, 244, 171, 10, 174, 185, 178, 144, 196, 52, 197, 233, 177, 66, 140, 9, 240, 234, 19, 246, 225, 96, 230, 32, 196, 3, 133, 108, 130, 146, 200, 247, 162, 92, 190, 70, 105, 174, 128, 25, 135, 50, 70, 37, 13, 65, 72, 242, 17, 199, 202, 94, 146, 67, 99, 9, 202, 31, 48, 91, 105, 223, 75, 86, 145, 172, 163, 109, 147, 80, 72, 108, 26, 185, 199, 73, 183, 57, 234, 158, 5, 152, 148 } });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "Default", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-ffffffffffff"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("00000000-0000-0000-ffff-ffffffffffff"), "", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserKey", "CreateTime", "EmailAddress", "FirstName", "LastName", "LoginName", "ModifyTime", "PasswordHash", "PasswordSalt", "SemesterDefinitionGroupKey" },
                values: new object[] { new Guid("00000000-0000-0000-0000-ffffffffffff"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 14, 46, 74, 230, 66, 229, 109, 33, 158, 97, 152, 81, 69, 76, 205, 85, 70, 125, 57, 178, 39, 162, 152, 169, 113, 70, 53, 60, 72, 66, 118, 228, 41, 30, 7, 224, 162, 120, 66, 116, 143, 152, 170, 184, 27, 9, 107, 63, 150, 130, 185, 90, 251, 53, 163, 133, 207, 238, 242, 200, 38, 166, 19, 67 }, new byte[] { 83, 57, 228, 12, 190, 246, 80, 208, 26, 7, 244, 88, 175, 138, 31, 126, 158, 252, 126, 84, 116, 44, 57, 71, 193, 6, 216, 214, 212, 218, 189, 185, 13, 106, 242, 173, 253, 152, 75, 137, 234, 142, 109, 80, 140, 150, 190, 57, 91, 254, 36, 240, 63, 234, 31, 82, 80, 25, 102, 50, 234, 192, 125, 85, 189, 22, 38, 82, 185, 178, 110, 48, 56, 54, 100, 66, 35, 33, 186, 89, 148, 193, 59, 221, 143, 240, 156, 78, 45, 127, 207, 24, 170, 189, 7, 14, 217, 62, 241, 40, 79, 216, 95, 104, 57, 102, 160, 16, 109, 179, 222, 219, 134, 243, 58, 173, 190, 95, 152, 31, 167, 227, 90, 125, 45, 66, 255, 147 }, new Guid("00000000-0000-0000-ffff-ffffffffffff") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey", "UserKey" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Odpowiedź ustna", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-ffffffffffff") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Kartkówka", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-ffffffffffff") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Projekt zespołowy", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-ffffffffffff") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Projekt zaliczeniowy", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-ffffffffffff") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Definition",
                keyColumn: "DefinitionKey",
                keyValue: new Guid("00000000-0000-0000-0000-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "DefinitionGroup",
                keyColumn: "DefinitionGroupKey",
                keyValue: new Guid("00000000-0000-0000-ffff-ffffffffffff"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey", "UserKey" },
                values: new object[,]
                {
                    { new Guid("9a684681-ffac-42e6-97a5-c07fb18e2a32"), "Odpowiedź ustna", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c94de30c-a03a-4432-91a1-310ace86050a"), "Kartkówka", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("27fd71bf-f9e1-4293-a494-be76b477c706"), "Projekt zespołowy", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("9969b359-b888-4d07-8e0a-f79234f58adb"), "Projekt zaliczeniowy", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 88, 220, 138, 39, 99, 23, 96, 153, 60, 102, 53, 102, 243, 104, 85, 107, 203, 136, 231, 182, 54, 91, 51, 223, 120, 98, 244, 65, 132, 57, 10, 244, 60, 245, 201, 93, 235, 141, 34, 6, 101, 252, 229, 105, 136, 66, 238, 141, 91, 206, 140, 175, 154, 61, 133, 160, 253, 78, 27, 18, 186, 224, 134 }, new byte[] { 188, 147, 189, 179, 90, 108, 22, 221, 182, 34, 73, 200, 253, 163, 183, 246, 88, 68, 52, 17, 5, 118, 12, 98, 133, 190, 245, 144, 13, 209, 81, 111, 93, 71, 179, 207, 188, 133, 74, 123, 116, 91, 114, 242, 102, 111, 50, 2, 34, 76, 31, 255, 60, 105, 136, 143, 104, 186, 90, 8, 165, 53, 221, 130, 33, 146, 166, 101, 38, 148, 81, 157, 148, 212, 49, 193, 21, 19, 15, 190, 79, 27, 62, 195, 144, 241, 113, 199, 164, 36, 162, 220, 217, 206, 130, 126, 179, 32, 98, 176, 181, 65, 234, 142, 46, 88, 79, 238, 111, 33, 216, 164, 3, 21, 230, 55, 66, 34, 70, 88, 77, 169, 23, 67, 54, 4, 211, 38 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserKey",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 88, 220, 138, 39, 99, 23, 96, 153, 60, 102, 53, 102, 243, 104, 85, 107, 203, 136, 231, 182, 54, 91, 51, 223, 120, 98, 244, 65, 132, 57, 10, 244, 60, 245, 201, 93, 235, 141, 34, 6, 101, 252, 229, 105, 136, 66, 238, 141, 91, 206, 140, 175, 154, 61, 133, 160, 253, 78, 27, 18, 186, 224, 134 }, new byte[] { 188, 147, 189, 179, 90, 108, 22, 221, 182, 34, 73, 200, 253, 163, 183, 246, 88, 68, 52, 17, 5, 118, 12, 98, 133, 190, 245, 144, 13, 209, 81, 111, 93, 71, 179, 207, 188, 133, 74, 123, 116, 91, 114, 242, 102, 111, 50, 2, 34, 76, 31, 255, 60, 105, 136, 143, 104, 186, 90, 8, 165, 53, 221, 130, 33, 146, 166, 101, 38, 148, 81, 157, 148, 212, 49, 193, 21, 19, 15, 190, 79, 27, 62, 195, 144, 241, 113, 199, 164, 36, 162, 220, 217, 206, 130, 126, 179, 32, 98, 176, 181, 65, 234, 142, 46, 88, 79, 238, 111, 33, 216, 164, 3, 21, 230, 55, 66, 34, 70, 88, 77, 169, 23, 67, 54, 4, 211, 38 } });
        }
    }
}

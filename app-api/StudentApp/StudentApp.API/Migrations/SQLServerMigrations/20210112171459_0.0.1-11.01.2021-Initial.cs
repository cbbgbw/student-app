using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00111012021Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryKey);
                });

            migrationBuilder.CreateTable(
                name: "DefinitionGroup",
                columns: table => new
                {
                    DefinitionGroupKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinitionGroup", x => x.DefinitionGroupKey);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusKey);
                });

            migrationBuilder.CreateTable(
                name: "Definition",
                columns: table => new
                {
                    DefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionGroupKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definition", x => x.DefinitionKey);
                    table.ForeignKey(
                        name: "FK_Definition_DefinitionGroup_DefinitionGroupKey",
                        column: x => x.DefinitionGroupKey,
                        principalTable: "DefinitionGroup",
                        principalColumn: "DefinitionGroupKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemesterDefinitionGroupKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserKey);
                    table.ForeignKey(
                        name: "FK_User_DefinitionGroup_SemesterDefinitionGroupKey",
                        column: x => x.SemesterDefinitionGroupKey,
                        principalTable: "DefinitionGroup",
                        principalColumn: "DefinitionGroupKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    TypeDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasProjectToPass = table.Column<bool>(type: "bit", nullable: false),
                    SemesterDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectKey);
                    table.ForeignKey(
                        name: "FK_Subject_Definition_SemesterDefinitionKey",
                        column: x => x.SemesterDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey");
                    table.ForeignKey(
                        name: "FK_Subject_Definition_TypeDefinitionKey",
                        column: x => x.TypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadlineTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NecessaryToPass = table.Column<bool>(type: "bit", nullable: false),
                    ProjectStatusKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    WorkingAreaKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectKey);
                    table.ForeignKey(
                        name: "FK_Project_Category_CategoryKey",
                        column: x => x.CategoryKey,
                        principalTable: "Category",
                        principalColumn: "CategoryKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Definition_TypeDefinitionKey",
                        column: x => x.TypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Status_ProjectStatusKey",
                        column: x => x.ProjectStatusKey,
                        principalTable: "Status",
                        principalColumn: "StatusKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Subject_SubjectKey",
                        column: x => x.SubjectKey,
                        principalTable: "Subject",
                        principalColumn: "SubjectKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey" },
                values: new object[,]
                {
                    { new Guid("13afbe50-33e6-40a1-8d3d-772ea51de83c"), "Odpowiedź ustna", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), 1, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("ab5118a4-e7db-4b4d-9f36-c495fdc5be2f"), "Kartkówka", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), 2, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("b2ee3a2c-7bfc-470c-97d2-e2cb52cf48bf"), "Projekt zespołowy", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), 1, new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("c9666768-39ed-4a32-b294-9891a3859317"), "Projekt zaliczeniowy", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), 2, new Guid("00000000-0000-0000-0000-000000000012") }
                });

            migrationBuilder.InsertData(
                table: "DefinitionGroup",
                columns: new[] { "DefinitionGroupKey", "CreateTime", "Description", "GroupName", "ModifyTime" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Typ zajęć", "SUBJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Typ projektu", "PROJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192) },
                    { new Guid("23dead7a-5218-4f7f-bd41-717f8e76ccc3"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Semestr użytkownika admin", "admin_SEMESTERS", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192) }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusKey", "Color", "CreateTime", "Description", "ModifyTime", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "ffffff", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Nowy", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ffffff", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Otwarty", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "ffffff", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "W trakcie", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "ffffff", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Wstrzymany", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "ffffff", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Zakończony", 4 }
                });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "Default", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Laboratoria" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Wykład" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Projekt" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "Egzamin" },
                    { new Guid("b30ef1a5-c3b5-4eff-85bb-a1e5ec518604"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), true, new Guid("23dead7a-5218-4f7f-bd41-717f8e76ccc3"), "admin_SEMESTERS", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "1" },
                    { new Guid("63f8352c-adf7-4bdc-9f4a-659cb595e67a"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("23dead7a-5218-4f7f-bd41-717f8e76ccc3"), "admin_SEMESTERS", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "2" },
                    { new Guid("ce19b202-a089-4283-a48f-87265f5f2b60"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), false, new Guid("23dead7a-5218-4f7f-bd41-717f8e76ccc3"), "admin_SEMESTERS", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserKey", "CreateTime", "EmailAddress", "FirstName", "LastName", "LoginName", "ModifyTime", "Password", "SemesterDefinitionGroupKey" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "", "admin", "", "admin", new DateTime(2021, 1, 12, 18, 14, 58, 638, DateTimeKind.Local).AddTicks(2192), "cyberbug2021", new Guid("23dead7a-5218-4f7f-bd41-717f8e76ccc3") });

            migrationBuilder.CreateIndex(
                name: "IX_Definition_DefinitionGroupKey",
                table: "Definition",
                column: "DefinitionGroupKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryKey",
                table: "Project",
                column: "CategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusKey",
                table: "Project",
                column: "ProjectStatusKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SubjectKey",
                table: "Project",
                column: "SubjectKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TypeDefinitionKey",
                table: "Project",
                column: "TypeDefinitionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SemesterDefinitionKey",
                table: "Subject",
                column: "SemesterDefinitionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TypeDefinitionKey",
                table: "Subject",
                column: "TypeDefinitionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SemesterDefinitionGroupKey",
                table: "User",
                column: "SemesterDefinitionGroupKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Definition");

            migrationBuilder.DropTable(
                name: "DefinitionGroup");
        }
    }
}

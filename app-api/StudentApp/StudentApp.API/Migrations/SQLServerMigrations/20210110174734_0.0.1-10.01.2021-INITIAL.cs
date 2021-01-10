using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class _00110012021INITIAL : Migration
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
                        onDelete: ReferentialAction.NoAction);
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
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Subject_Definition_TypeDefinitionKey",
                        column: x => x.TypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Definition_TypeDefinitionKey",
                        column: x => x.TypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Status_ProjectStatusKey",
                        column: x => x.ProjectStatusKey,
                        principalTable: "Status",
                        principalColumn: "StatusKey",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Project_Subject_SubjectKey",
                        column: x => x.SubjectKey,
                        principalTable: "Subject",
                        principalColumn: "SubjectKey",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryKey", "CategoryName", "CreateTime", "ModifyTime", "OrderIndex", "ProjectTypeKey" },
                values: new object[,]
                {
                    { new Guid("6a2e29bd-a481-4bf2-bbe8-40958f65c91f"), "Odpowiedź ustna", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), 1, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("a951eccf-bcca-405d-9323-230995e5f887"), "Kartkówka", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), 2, new Guid("00000000-0000-0000-0000-000000000022") },
                    { new Guid("3c8d0757-efb3-483d-848b-2882a3137492"), "Projekt zespołowy", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), 1, new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("1ad6f3db-bea8-4bd6-8229-eae0ba811779"), "Projekt zaliczeniowy", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), 2, new Guid("00000000-0000-0000-0000-000000000012") }
                });

            migrationBuilder.InsertData(
                table: "DefinitionGroup",
                columns: new[] { "DefinitionGroupKey", "CreateTime", "Description", "GroupName", "ModifyTime" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Typ zajęć", "SUBJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Typ projektu", "PROJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506) },
                    { new Guid("a0d821c9-17ea-4f6c-9dc1-1a54d1f5c5a8"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Semestr użytkownika admin", "admin_SEMESTERS", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506) }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusKey", "Color", "CreateTime", "Description", "ModifyTime", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "ffffff", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Nowy", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ffffff", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Otwarty", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "ffffff", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "W trakcie", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "ffffff", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Wstrzymany", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "ffffff", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Zakończony", 4 }
                });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "Default", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), false, new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Laboratoria" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), false, new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Wykład" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), false, new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Projekt" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), false, new Guid("00000000-0000-0000-0000-000000000002"), "PROJECT_TYPES", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "Egzamin" },
                    { new Guid("000c8717-ae15-421b-af04-204d87e82d51"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), true, new Guid("a0d821c9-17ea-4f6c-9dc1-1a54d1f5c5a8"), "admin_SEMESTERS", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "1" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserKey", "CreateTime", "EmailAddress", "FirstName", "LastName", "LoginName", "ModifyTime", "Password", "SemesterDefinitionGroupKey" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "", "admin", "", "admin", new DateTime(2021, 1, 10, 18, 47, 33, 654, DateTimeKind.Local).AddTicks(6506), "cyberbug2021", new Guid("a0d821c9-17ea-4f6c-9dc1-1a54d1f5c5a8") });

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
                column: "SemesterDefinitionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TypeDefinitionKey",
                table: "Subject",
                column: "TypeDefinitionKey");

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

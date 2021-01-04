using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations.SQLServerMigrations
{
    public partial class InitialMigration : Migration
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
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
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
                name: "Subject",
                columns: table => new
                {
                    SubjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    TypeDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasProjectToPass = table.Column<bool>(type: "bit", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectKey);
                    table.ForeignKey(
                        name: "FK_Subject_Definition_TypeDefinitionKey",
                        column: x => x.TypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "DefinitionGroup",
                columns: new[] { "DefinitionGroupKey", "CreateTime", "Description", "GroupName", "ModifyTime" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Typ zajęć", "SUBJECT_TYPES", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusKey", "Color", "CreateTime", "Description", "ModifyTime", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "ffffff", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Nowy", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "ffffff", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Otwarty", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "ffffff", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "W trakcie", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "ffffff", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Wstrzymany", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "ffffff", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Zakończony", 4 }
                });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Laboratoria" });

            migrationBuilder.InsertData(
                table: "Definition",
                columns: new[] { "DefinitionKey", "CreateTime", "DefinitionGroupKey", "GroupName", "ModifyTime", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), new Guid("00000000-0000-0000-0000-000000000001"), "SUBJECT_TYPES", new DateTime(2021, 1, 3, 19, 47, 24, 29, DateTimeKind.Local).AddTicks(2986), "Wykład" });

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
                name: "IX_Subject_TypeDefinitionKey",
                table: "Subject",
                column: "TypeDefinitionKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

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

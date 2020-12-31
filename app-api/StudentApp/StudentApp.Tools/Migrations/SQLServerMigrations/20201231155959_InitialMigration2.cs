using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.API.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefinitionGroup",
                columns: table => new
                {
                    DefinitionGroupKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinitionGroup", x => x.DefinitionGroupKey);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasProjectToPass = table.Column<bool>(type: "bit", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectKey);
                });

            migrationBuilder.CreateTable(
                name: "Definition",
                columns: table => new
                {
                    DefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionGroupKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionGroupKey1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definition", x => x.DefinitionKey);
                    table.ForeignKey(
                        name: "FK_Definition_DefinitionGroup_DefinitionGroupKey1",
                        column: x => x.DefinitionGroupKey1,
                        principalTable: "DefinitionGroup",
                        principalColumn: "DefinitionGroupKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionTypeDefinitionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadlineTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NecessaryToPass = table.Column<bool>(type: "bit", nullable: false),
                    CurrentProjectStateKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectKey1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_Project_Definition_DefinitionTypeDefinitionKey",
                        column: x => x.DefinitionTypeDefinitionKey,
                        principalTable: "Definition",
                        principalColumn: "DefinitionKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Subject_SubjectKey1",
                        column: x => x.SubjectKey1,
                        principalTable: "Subject",
                        principalColumn: "SubjectKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Definition_DefinitionGroupKey1",
                table: "Definition",
                column: "DefinitionGroupKey1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DefinitionTypeDefinitionKey",
                table: "Project",
                column: "DefinitionTypeDefinitionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Project_SubjectKey1",
                table: "Project",
                column: "SubjectKey1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Definition");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "DefinitionGroup");
        }
    }
}

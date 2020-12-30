using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.Tools.Migrations.SqliteMigrations
{
    public partial class SubjectModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentSubjectStateKey",
                table: "Subject",
                newName: "StatusDefinitionKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusDefinitionKey",
                table: "Subject",
                newName: "CurrentSubjectStateKey");
        }
    }
}

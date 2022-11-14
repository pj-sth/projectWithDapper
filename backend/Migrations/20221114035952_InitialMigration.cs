using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    studentname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.studentid);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    subjectid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subjectname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.subjectid);
                });

            migrationBuilder.CreateTable(
                name: "studentsubjects",
                columns: table => new
                {
                    studentsubjectid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    studentid = table.Column<int>(type: "integer", nullable: false),
                    subjectid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsubjects", x => x.studentsubjectid);
                    table.ForeignKey(
                        name: "FK_studentsubjects_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentsubjects_subjects_subjectid",
                        column: x => x.subjectid,
                        principalTable: "subjects",
                        principalColumn: "subjectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentsubjects_studentid",
                table: "studentsubjects",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_studentsubjects_subjectid",
                table: "studentsubjects",
                column: "subjectid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentsubjects");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}

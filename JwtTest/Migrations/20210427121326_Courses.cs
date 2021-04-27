using Microsoft.EntityFrameworkCore.Migrations;

namespace JwtTest.Migrations
{
    public partial class Courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DepNo = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourses", x => new { x.DepNo, x.CourseId });
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Departments_DepNo",
                        column: x => x.DepNo,
                        principalTable: "Departments",
                        principalColumn: "DeptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studentcourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentcourses", x => new { x.studentID, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Studentcourses_AspNetUsers_studentID",
                        column: x => x.studentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studentcourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseId",
                table: "DepartmentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Studentcourses_CourseId",
                table: "Studentcourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentCourses");

            migrationBuilder.DropTable(
                name: "Studentcourses");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

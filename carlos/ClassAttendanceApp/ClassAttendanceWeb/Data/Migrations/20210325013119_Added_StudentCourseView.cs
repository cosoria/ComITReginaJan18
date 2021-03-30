using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassAttendance.Data.Migrations
{
    public partial class Added_StudentCourseView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[StudentCourse]
            AS
                SELECT 
                    Courses.Title, 
                    Courses.StartDate, 
                    Students.FirstName, 
                    Students.LastName
                FROM 
                    Courses 
                INNER JOIN
                    Students 
                    ON Courses.Id = Students.CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [StudentCourse]");
        }
    }
}

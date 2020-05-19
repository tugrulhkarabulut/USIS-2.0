namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.course_registrations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentID = c.Int(nullable: false),
                        openedCourseID = c.Int(nullable: false),
                        grade = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.opened_courses", t => t.openedCourseID, cascadeDelete: true)
                .ForeignKey("dbo.students", t => t.studentID, cascadeDelete: true)
                .Index(t => t.studentID)
                .Index(t => t.openedCourseID);
            
            CreateTable(
                "dbo.opened_courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        courseID = c.Int(nullable: false),
                        lecturerID = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        semester = c.String(),
                        capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.courses", t => t.courseID, cascadeDelete: true)
                .ForeignKey("dbo.lecturers", t => t.lecturerID, cascadeDelete: true)
                .Index(t => t.courseID)
                .Index(t => t.lecturerID);
            
            CreateTable(
                "dbo.courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        courseCode = c.String(),
                        courseName = c.String(),
                        departmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.departments", t => t.departmentID, cascadeDelete: true)
                .Index(t => t.departmentID);
            
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        facultyID = c.Int(nullable: false),
                        departmentName = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.faculties", t => t.facultyID, cascadeDelete: true)
                .Index(t => t.facultyID);
            
            CreateTable(
                "dbo.faculties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        facultyName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.lecturers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        lecturerName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentNumber = c.Int(nullable: false),
                        departmentID = c.Int(nullable: false),
                        startYear = c.Int(nullable: false),
                        gpa = c.Double(nullable: false),
                        studentName = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.departments", t => t.departmentID, cascadeDelete: false)
                .Index(t => t.departmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.students", "departmentID", "dbo.departments");
            DropForeignKey("dbo.course_registrations", "studentID", "dbo.students");
            DropForeignKey("dbo.opened_courses", "lecturerID", "dbo.lecturers");
            DropForeignKey("dbo.course_registrations", "openedCourseID", "dbo.opened_courses");
            DropForeignKey("dbo.opened_courses", "courseID", "dbo.courses");
            DropForeignKey("dbo.courses", "departmentID", "dbo.departments");
            DropForeignKey("dbo.departments", "facultyID", "dbo.faculties");
            DropIndex("dbo.students", new[] { "departmentID" });
            DropIndex("dbo.departments", new[] { "facultyID" });
            DropIndex("dbo.courses", new[] { "departmentID" });
            DropIndex("dbo.opened_courses", new[] { "lecturerID" });
            DropIndex("dbo.opened_courses", new[] { "courseID" });
            DropIndex("dbo.course_registrations", new[] { "openedCourseID" });
            DropIndex("dbo.course_registrations", new[] { "studentID" });
            DropTable("dbo.students");
            DropTable("dbo.lecturers");
            DropTable("dbo.faculties");
            DropTable("dbo.departments");
            DropTable("dbo.courses");
            DropTable("dbo.opened_courses");
            DropTable("dbo.course_registrations");
        }
    }
}

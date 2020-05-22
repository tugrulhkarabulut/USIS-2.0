namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courses_added_year_semester_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.courses", "year", c => c.Int(nullable: false));
            AddColumn("dbo.courses", "semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.courses", "semester");
            DropColumn("dbo.courses", "year");
        }
    }
}

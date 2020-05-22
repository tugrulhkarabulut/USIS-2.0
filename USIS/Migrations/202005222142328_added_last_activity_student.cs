namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_last_activity_student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.students", "lastActivity", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.students", "lastActivity");
        }
    }
}

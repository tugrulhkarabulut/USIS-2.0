namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_email_students : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.students", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.students", "email");
        }
    }
}

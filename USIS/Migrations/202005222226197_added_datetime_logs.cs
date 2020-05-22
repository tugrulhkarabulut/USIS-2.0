namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_datetime_logs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.logs", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.logs", "dateTime");
        }
    }
}

namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_credit_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.courses", "credit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.courses", "credit");
        }
    }
}

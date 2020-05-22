namespace USIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_logs_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.logs");
        }
    }
}

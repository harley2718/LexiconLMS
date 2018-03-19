namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activities2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Type", c => c.Int(nullable: false));
            DropTable("dbo.ActivityTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Activities", "Type");
        }
    }
}

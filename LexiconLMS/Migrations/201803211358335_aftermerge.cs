namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aftermerge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ModuleId", c => c.Int(nullable: false));
            AddColumn("dbo.Activities", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activities", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activities", "EndTime");
            DropColumn("dbo.Activities", "StartTime");
            DropColumn("dbo.Activities", "ModuleId");
        }
    }
}

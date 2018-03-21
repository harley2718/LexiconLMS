namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedModuleIdToActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ModuleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "ModuleId");
        }
    }
}

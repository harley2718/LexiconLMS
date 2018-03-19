namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Description", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "Name", c => c.String());
            DropColumn("dbo.Activities", "Description");
        }
    }
}

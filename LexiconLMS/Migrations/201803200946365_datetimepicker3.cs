namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimepicker3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "EndDate");
        }
    }
}

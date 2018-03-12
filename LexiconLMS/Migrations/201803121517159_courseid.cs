namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modules", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "CourseId");
        }
    }
}

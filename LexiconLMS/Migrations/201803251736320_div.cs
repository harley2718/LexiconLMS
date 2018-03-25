namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class div : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Course_Id", c => c.Int());
            AddColumn("dbo.Courses", "ModulesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "Course_Id");
            AddForeignKey("dbo.Activities", "Course_Id", "dbo.Courses", "Id");
            DropColumn("dbo.Courses", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
            DropForeignKey("dbo.Activities", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Activities", new[] { "Course_Id" });
            DropColumn("dbo.Courses", "ModulesId");
            DropColumn("dbo.Activities", "Course_Id");
        }
    }
}

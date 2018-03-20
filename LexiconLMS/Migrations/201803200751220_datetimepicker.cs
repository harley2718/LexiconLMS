namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimepicker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "CourseId" });
            DropColumn("dbo.Activities", "EndDate");
            DropColumn("dbo.AspNetUsers", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CourseId", c => c.Int());
            AddColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CourseId");
            AddForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses", "Id");
        }
    }
}

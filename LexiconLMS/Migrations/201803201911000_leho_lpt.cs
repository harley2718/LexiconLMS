namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leho_lpt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "CourseId" });
            AddColumn("dbo.Activities", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Activities", "Description", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "CourseId");
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
            
            AddColumn("dbo.AspNetUsers", "CourseId", c => c.Int());
            AlterColumn("dbo.Activities", "Name", c => c.String());
            DropColumn("dbo.Activities", "Description");
            DropColumn("dbo.Activities", "Type");
            CreateIndex("dbo.AspNetUsers", "CourseId");
            AddForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses", "Id");
        }
    }
}

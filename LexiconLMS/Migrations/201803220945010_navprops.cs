namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navprops : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Activities", "ModuleId");
            CreateIndex("dbo.Modules", "CourseId");
            AddForeignKey("dbo.Activities", "ModuleId", "dbo.Modules", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Modules", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Activities", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Modules", new[] { "CourseId" });
            DropIndex("dbo.Activities", new[] { "ModuleId" });
        }
    }
}

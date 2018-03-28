namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userviewproblems : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        UserFName = c.String(nullable: false, maxLength: 20),
                        UserLName = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        UserEmail = c.String(nullable: false, maxLength: 50),
                        UserPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

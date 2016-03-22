namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Info = c.String(),
                        Job_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID)
                .Index(t => t.Job_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Info = c.String(),
                        Resume_FileID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Files", t => t.Resume_FileID)
                .Index(t => t.Resume_FileID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FileID);
            
            AddColumn("dbo.AspNetUsers", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.JobSeekers", "Resume_FileID", "dbo.Files");
            DropForeignKey("dbo.Employers", "Job_ID", "dbo.Jobs");
            DropIndex("dbo.JobSeekers", new[] { "Resume_FileID" });
            DropIndex("dbo.Employers", new[] { "Job_ID" });
            DropColumn("dbo.AspNetUsers", "Role");
            DropTable("dbo.Files");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employers");
        }
    }
}

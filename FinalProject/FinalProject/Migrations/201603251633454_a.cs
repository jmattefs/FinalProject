namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobSeekers", "Resume_FileID", "dbo.Files");
            DropIndex("dbo.JobSeekers", new[] { "Resume_FileID" });
            AddColumn("dbo.JobSeekers", "ResumeID", c => c.Int(nullable: false));
            DropColumn("dbo.JobSeekers", "Resume_FileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobSeekers", "Resume_FileID", c => c.Int());
            DropColumn("dbo.JobSeekers", "ResumeID");
            CreateIndex("dbo.JobSeekers", "Resume_FileID");
            AddForeignKey("dbo.JobSeekers", "Resume_FileID", "dbo.Files", "FileID");
        }
    }
}

namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "UploadedResume", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "UploadedResume");
        }
    }
}

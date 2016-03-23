namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "Survey1Complete", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobSeekers", "Survey2Complete", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobSeekers", "Survey3Complete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "Survey3Complete");
            DropColumn("dbo.JobSeekers", "Survey2Complete");
            DropColumn("dbo.JobSeekers", "Survey1Complete");
        }
    }
}

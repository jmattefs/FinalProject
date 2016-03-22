namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "isSubscribed", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobSeekers", "Survey1Score", c => c.Int(nullable: false));
            AddColumn("dbo.JobSeekers", "Survey2Score", c => c.Int(nullable: false));
            AddColumn("dbo.JobSeekers", "Survey3Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "Survey3Score");
            DropColumn("dbo.JobSeekers", "Survey2Score");
            DropColumn("dbo.JobSeekers", "Survey1Score");
            DropColumn("dbo.Employers", "isSubscribed");
        }
    }
}

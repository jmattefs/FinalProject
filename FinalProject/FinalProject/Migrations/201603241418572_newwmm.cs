namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newwmm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personalities", "Q6", c => c.Int(nullable: false));
            AddColumn("dbo.Personalities", "Q7", c => c.Int(nullable: false));
            AlterColumn("dbo.JobSeekers", "Survey2Score", c => c.String());
            AlterColumn("dbo.JobSeekers", "Survey3Score", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobSeekers", "Survey3Score", c => c.Int(nullable: false));
            AlterColumn("dbo.JobSeekers", "Survey2Score", c => c.Int(nullable: false));
            DropColumn("dbo.Personalities", "Q7");
            DropColumn("dbo.Personalities", "Q6");
        }
    }
}

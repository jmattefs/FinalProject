namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "UserId");
        }
    }
}

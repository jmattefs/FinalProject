namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdffds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "EmailMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "EmailMessage");
        }
    }
}

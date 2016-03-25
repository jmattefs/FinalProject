namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masdfdsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobSeekers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobSeekers", "Email");
        }
    }
}

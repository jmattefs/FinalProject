namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employers", "Email");
        }
    }
}

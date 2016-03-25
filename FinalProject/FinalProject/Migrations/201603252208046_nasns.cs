namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nasns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "TestBScore", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "TestCScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "TestCScore", c => c.String());
            AlterColumn("dbo.Jobs", "TestBScore", c => c.String());
        }
    }
}

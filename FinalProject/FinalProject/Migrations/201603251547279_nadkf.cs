namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nadkf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "FileName");
        }
    }
}

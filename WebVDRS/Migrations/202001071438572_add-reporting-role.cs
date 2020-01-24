namespace WebVDRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreportingrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reportings", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reportings", "Role");
        }
    }
}

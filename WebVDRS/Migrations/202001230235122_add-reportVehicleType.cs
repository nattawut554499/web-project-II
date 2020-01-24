namespace WebVDRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreportVehicleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reportings", "VehicleType", c => c.String());
            AddColumn("dbo.Reportings", "IsTheSameCase", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reportings", "IsTheSameCase");
            DropColumn("dbo.Reportings", "VehicleType");
        }
    }
}

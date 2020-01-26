namespace WebVDRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class englishName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentNameEng", c => c.String());
            AddColumn("dbo.Students", "StudentLastnameEng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentLastnameEng");
            DropColumn("dbo.Students", "StudentNameEng");
        }
    }
}

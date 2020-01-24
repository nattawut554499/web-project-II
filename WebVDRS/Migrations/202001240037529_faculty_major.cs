namespace WebVDRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faculty_major : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacultyWUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MajorWUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        FacultyValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MajorWUs");
            DropTable("dbo.FacultyWUs");
        }
    }
}

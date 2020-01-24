namespace WebVDRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProject1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reportings", "SuspectStudentId", c => c.String());
            AddColumn("dbo.Reportings", "SuspectFirstName", c => c.String());
            AddColumn("dbo.Reportings", "SuspectLastName", c => c.String());
            AddColumn("dbo.Reportings", "SuspectMajor", c => c.String());
            AddColumn("dbo.Reportings", "SuspectFaculty", c => c.String());
            AddColumn("dbo.Students", "StudentMajor", c => c.String());
            AddColumn("dbo.Students", "StudentFaculty", c => c.String());
            AddColumn("dbo.Students", "StudyStatus", c => c.String());
            AddColumn("dbo.Students", "StudyGender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudyGender");
            DropColumn("dbo.Students", "StudyStatus");
            DropColumn("dbo.Students", "StudentFaculty");
            DropColumn("dbo.Students", "StudentMajor");
            DropColumn("dbo.Reportings", "SuspectFaculty");
            DropColumn("dbo.Reportings", "SuspectMajor");
            DropColumn("dbo.Reportings", "SuspectLastName");
            DropColumn("dbo.Reportings", "SuspectFirstName");
            DropColumn("dbo.Reportings", "SuspectStudentId");
        }
    }
}

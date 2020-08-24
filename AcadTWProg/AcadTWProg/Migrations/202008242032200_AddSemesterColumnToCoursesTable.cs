namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Semester");
        }
    }
}

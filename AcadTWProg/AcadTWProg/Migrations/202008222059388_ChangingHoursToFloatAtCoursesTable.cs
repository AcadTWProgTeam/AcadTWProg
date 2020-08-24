namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingHoursToFloatAtCoursesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Hours", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Hours", c => c.Int(nullable: false));
        }
    }
}

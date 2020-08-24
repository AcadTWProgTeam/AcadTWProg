namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScheduleDataColumnToScheduleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "ScheduleData", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "ScheduleData");
        }
    }
}

namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdsToScheduleDataTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleDatas", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleDatas", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleDatas", "RoomId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleDatas", "RoomId");
            DropColumn("dbo.ScheduleDatas", "TeacherId");
            DropColumn("dbo.ScheduleDatas", "CourseId");
        }
    }
}

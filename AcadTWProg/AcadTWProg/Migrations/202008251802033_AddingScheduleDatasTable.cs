namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingScheduleDatasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        ColSpan = c.Int(nullable: false),
                        Code = c.String(),
                        TeacherName = c.String(),
                        Room = c.String(),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleDatas", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.ScheduleDatas", new[] { "ScheduleId" });
            DropTable("dbo.ScheduleDatas");
        }
    }
}

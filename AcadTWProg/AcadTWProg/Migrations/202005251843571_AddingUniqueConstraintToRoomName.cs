namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUniqueConstraintToRoomName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "Name", c => c.String(nullable: false, maxLength: 5));
            CreateIndex("dbo.Rooms", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rooms", new[] { "Name" });
            AlterColumn("dbo.Rooms", "Name", c => c.String(nullable: false));
        }
    }
}

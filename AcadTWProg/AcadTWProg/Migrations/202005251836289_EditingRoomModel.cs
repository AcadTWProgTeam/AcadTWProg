namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditingRoomModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Rooms");
            AddColumn("dbo.Rooms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Rooms", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rooms", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "ID", c => c.String(nullable: false, maxLength: 5));
            DropColumn("dbo.Rooms", "Name");
            AddPrimaryKey("dbo.Rooms", "Id");
        }
    }
}

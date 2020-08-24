namespace AcadTWProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentIdColumnToAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropColumn("dbo.AspNetUsers", "DepartmentId");
        }
    }
}

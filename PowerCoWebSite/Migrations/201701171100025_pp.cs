namespace PowerCoWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Position_Id", "dbo.EmployeePositions");
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            AddColumn("dbo.Employees", "Position", c => c.String());
            DropColumn("dbo.Employees", "Position_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Position_Id", c => c.Int());
            DropColumn("dbo.Employees", "Position");
            DropColumn("dbo.Employees", "DepartmentName");
            CreateIndex("dbo.Employees", "Position_Id");
            AddForeignKey("dbo.Employees", "Position_Id", "dbo.EmployeePositions", "Id");
        }
    }
}

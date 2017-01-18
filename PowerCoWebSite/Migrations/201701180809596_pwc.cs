namespace PowerCoWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pwc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Position_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Position_Id");
            AddForeignKey("dbo.Employees", "Position_Id", "dbo.EmployeePositions", "Id");
            DropColumn("dbo.Employees", "DepartmentName");
            DropColumn("dbo.Employees", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Position", c => c.String());
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            DropForeignKey("dbo.Employees", "Position_Id", "dbo.EmployeePositions");
            DropIndex("dbo.Employees", new[] { "Position_Id" });
            DropColumn("dbo.Employees", "Position_Id");
        }
    }
}

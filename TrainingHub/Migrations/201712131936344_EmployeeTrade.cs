namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Trade", c => c.String());
            AddColumn("dbo.Employees", "Type", c => c.Byte(nullable: false));
            AddColumn("dbo.Employees", "Status", c => c.Byte(nullable: false));
            AddColumn("dbo.Employees", "CourseStatus", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "CourseStatus");
            DropColumn("dbo.Employees", "Status");
            DropColumn("dbo.Employees", "Type");
            DropColumn("dbo.Employees", "Trade");
        }
    }
}

namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBusinessUnit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "BusinessUnit_Id", "dbo.BusinessUnits");
            DropIndex("dbo.Employees", new[] { "BusinessUnit_Id" });
            DropColumn("dbo.Employees", "BusinessUnitId");
            DropColumn("dbo.Employees", "BusinessUnit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "BusinessUnit_Id", c => c.Int());
            AddColumn("dbo.Employees", "BusinessUnitId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Employees", "BusinessUnit_Id");
            AddForeignKey("dbo.Employees", "BusinessUnit_Id", "dbo.BusinessUnits", "Id");
        }
    }
}

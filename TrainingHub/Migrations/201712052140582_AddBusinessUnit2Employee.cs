namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessUnit2Employee : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BusinessUnits");
            AddColumn("dbo.Employees", "BusinessUnitId", c => c.Byte(nullable: false));
            AlterColumn("dbo.BusinessUnits", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.BusinessUnits", "Id");
            CreateIndex("dbo.Employees", "BusinessUnitId");
            AddForeignKey("dbo.Employees", "BusinessUnitId", "dbo.BusinessUnits", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "BusinessUnitId", "dbo.BusinessUnits");
            DropIndex("dbo.Employees", new[] { "BusinessUnitId" });
            DropPrimaryKey("dbo.BusinessUnits");
            AlterColumn("dbo.BusinessUnits", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Employees", "BusinessUnitId");
            AddPrimaryKey("dbo.BusinessUnits", "Id");
        }
    }
}

namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessUnit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "BusinessUnitId", c => c.Byte(nullable: false));
            AddColumn("dbo.Employees", "BusinessUnit_Id", c => c.Int());
            CreateIndex("dbo.Employees", "BusinessUnit_Id");
            AddForeignKey("dbo.Employees", "BusinessUnit_Id", "dbo.BusinessUnits", "Id");
            DropColumn("dbo.Employees", "TradeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "TradeID", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Employees", "BusinessUnit_Id", "dbo.BusinessUnits");
            DropIndex("dbo.Employees", new[] { "BusinessUnit_Id" });
            DropColumn("dbo.Employees", "BusinessUnit_Id");
            DropColumn("dbo.Employees", "BusinessUnitId");
            DropTable("dbo.BusinessUnits");
        }
    }
}

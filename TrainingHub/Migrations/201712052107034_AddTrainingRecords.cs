namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainingRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompletedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Course_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Employee_Id);
            
            AddColumn("dbo.Courses", "WarnNoOfDayBeforeExpire", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingRecords", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.TrainingRecords", "Course_Id", "dbo.Courses");
            DropIndex("dbo.TrainingRecords", new[] { "Employee_Id" });
            DropIndex("dbo.TrainingRecords", new[] { "Course_Id" });
            DropColumn("dbo.Courses", "WarnNoOfDayBeforeExpire");
            DropTable("dbo.TrainingRecords");
        }
    }
}

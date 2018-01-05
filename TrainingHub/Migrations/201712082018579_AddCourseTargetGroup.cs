namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTargetGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTargetGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TargetGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TargetGroups", t => t.TargetGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TargetGroupId);
            
            CreateTable(
                "dbo.TargetGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTargetGroups", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTargetGroups", "TargetGroupId", "dbo.TargetGroups");
            DropIndex("dbo.CourseTargetGroups", new[] { "TargetGroupId" });
            DropIndex("dbo.CourseTargetGroups", new[] { "CourseId" });
            DropTable("dbo.TargetGroups");
            DropTable("dbo.CourseTargetGroups");
        }
    }
}

namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupervisor2Course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "SupervisorTraining", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.Courses", "SupervisorTraining");
        }
    }
}

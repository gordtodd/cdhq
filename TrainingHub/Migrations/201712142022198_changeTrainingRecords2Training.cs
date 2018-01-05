namespace TrainingHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTrainingRecords2Training : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TrainingRecords", newName: "Trainings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Trainings", newName: "TrainingRecords");
        }
    }
}

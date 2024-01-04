namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInitiation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Psychologists",
                c => new
                    {
                        PsychologistId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                        CVPath = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.PsychologistId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        PsychologistId = c.Int(),
                        TreatmentPlanId = c.Int(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        Location = c.String(),
                        SessionNotes = c.String(),
                        IsCancelled = c.Boolean(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Psychologists", t => t.PsychologistId)
                .ForeignKey("dbo.TreatmentPlans", t => t.TreatmentPlanId)
                .Index(t => t.PsychologistId)
                .Index(t => t.TreatmentPlanId);
            
            CreateTable(
                "dbo.TreatmentPlans",
                c => new
                    {
                        TreatmentPlanId = c.Int(nullable: false, identity: true),
                        PsychologistId = c.Int(nullable: false),
                        PlanStartDate = c.DateTime(nullable: false),
                        PlanEndDate = c.DateTime(nullable: false),
                        PlanDetails = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentPlanId)
                .ForeignKey("dbo.Psychologists", t => t.PsychologistId, cascadeDelete: true)
                .Index(t => t.PsychologistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "TreatmentPlanId", "dbo.TreatmentPlans");
            DropForeignKey("dbo.TreatmentPlans", "PsychologistId", "dbo.Psychologists");
            DropForeignKey("dbo.Sessions", "PsychologistId", "dbo.Psychologists");
            DropIndex("dbo.TreatmentPlans", new[] { "PsychologistId" });
            DropIndex("dbo.Sessions", new[] { "TreatmentPlanId" });
            DropIndex("dbo.Sessions", new[] { "PsychologistId" });
            DropTable("dbo.TreatmentPlans");
            DropTable("dbo.Sessions");
            DropTable("dbo.Psychologists");
            DropTable("dbo.People");
        }
    }
}

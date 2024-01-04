namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInitiationMessageag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        ReceiverPerson_Id = c.Int(),
                        SenderPsychologist_PsychologistId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.People", t => t.ReceiverPerson_Id)
                .ForeignKey("dbo.Psychologists", t => t.SenderPsychologist_PsychologistId)
                .Index(t => t.ReceiverPerson_Id)
                .Index(t => t.SenderPsychologist_PsychologistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderPsychologist_PsychologistId", "dbo.Psychologists");
            DropForeignKey("dbo.Messages", "ReceiverPerson_Id", "dbo.People");
            DropIndex("dbo.Messages", new[] { "SenderPsychologist_PsychologistId" });
            DropIndex("dbo.Messages", new[] { "ReceiverPerson_Id" });
            DropTable("dbo.Messages");
        }
    }
}

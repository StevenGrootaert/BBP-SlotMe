 namespace SlotMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkMajors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Availability", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Availability", new[] { "UserId" });
            CreateTable(
                "dbo.Slot",
                c => new
                    {
                        SlotId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SlotStart = c.DateTime(nullable: false),
                        SlotEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SlotId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            DropTable("dbo.Availability");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Availability",
                c => new
                    {
                        TimeSlotId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SlotStart = c.DateTime(nullable: false),
                        SlotEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeSlotId);
            
            DropForeignKey("dbo.Slot", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Slot", new[] { "UserId" });
            DropTable("dbo.Slot");
            CreateIndex("dbo.Availability", "UserId");
            AddForeignKey("dbo.Availability", "UserId", "dbo.ApplicationUser", "Id");
        }
    }
}

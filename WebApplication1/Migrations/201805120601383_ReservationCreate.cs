namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ResevationID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        CheckedInDate = c.DateTime(nullable: false),
                        CheckedOutDate = c.DateTime(nullable: false),
                        ApplicationUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUsers_Id)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID)
                .Index(t => t.ApplicationUsers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "ApplicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUsers_Id" });
            DropIndex("dbo.Reservations", new[] { "RoomID" });
            DropTable("dbo.Reservations");
        }
    }
}

namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomupdate111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "ApplicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "ApplicationUsers_Id" });
            CreateTable(
                "dbo.RoomReservations",
                c => new
                    {
                        RR_ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        Bill = c.Double(nullable: false),
                        BookingStatus = c.String(),
                        ACheckIn = c.DateTime(nullable: false),
                        ACheckOut = c.DateTime(nullable: false),
                        ApplicationUsers_Id = c.String(maxLength: 128),
                        Rooms_RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.RR_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUsers_Id)
                .ForeignKey("dbo.Rooms", t => t.Rooms_RoomID)
                .Index(t => t.ApplicationUsers_Id)
                .Index(t => t.Rooms_RoomID);
            
            DropColumn("dbo.Rooms", "UserName");
            DropColumn("dbo.Rooms", "CheckInDate");
            DropColumn("dbo.Rooms", "CheckOutDate");
            DropColumn("dbo.Rooms", "NONights");
            DropColumn("dbo.Rooms", "Status");
            DropColumn("dbo.Rooms", "ApplicationUsers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ApplicationUsers_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Rooms", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "NONights", c => c.Double());
            AddColumn("dbo.Rooms", "CheckOutDate", c => c.DateTime());
            AddColumn("dbo.Rooms", "CheckInDate", c => c.DateTime());
            AddColumn("dbo.Rooms", "UserName", c => c.String());
            DropForeignKey("dbo.RoomReservations", "Rooms_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RoomReservations", "ApplicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RoomReservations", new[] { "Rooms_RoomID" });
            DropIndex("dbo.RoomReservations", new[] { "ApplicationUsers_Id" });
            DropTable("dbo.RoomReservations");
            CreateIndex("dbo.Rooms", "ApplicationUsers_Id");
            AddForeignKey("dbo.Rooms", "ApplicationUsers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

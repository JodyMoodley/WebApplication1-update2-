namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        CheckInID = c.Int(nullable: false, identity: true),
                        CheckInDate = c.DateTime(nullable: false),
                        ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckInID)
                .ForeignKey("dbo.RoomReservations", t => t.ReservationID, cascadeDelete: true)
                .Index(t => t.ReservationID);
            
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        CheckInID = c.Int(nullable: false, identity: true),
                        CheckOutDate = c.DateTime(nullable: false),
                        ReservationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckInID)
                .ForeignKey("dbo.RoomReservations", t => t.ReservationID, cascadeDelete: true)
                .Index(t => t.ReservationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "ReservationID", "dbo.RoomReservations");
            DropForeignKey("dbo.CheckIns", "ReservationID", "dbo.RoomReservations");
            DropIndex("dbo.CheckOuts", new[] { "ReservationID" });
            DropIndex("dbo.CheckIns", new[] { "ReservationID" });
            DropTable("dbo.CheckOuts");
            DropTable("dbo.CheckIns");
        }
    }
}

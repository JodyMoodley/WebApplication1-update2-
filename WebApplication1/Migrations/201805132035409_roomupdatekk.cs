namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomupdatekk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomReservations", "Rooms_RoomID", "dbo.Rooms");
            DropIndex("dbo.RoomReservations", new[] { "Rooms_RoomID" });
            RenameColumn(table: "dbo.RoomReservations", name: "Rooms_RoomID", newName: "RoomID");
            AlterColumn("dbo.RoomReservations", "RoomID", c => c.Int(nullable: false));
            CreateIndex("dbo.RoomReservations", "RoomID");
            AddForeignKey("dbo.RoomReservations", "RoomID", "dbo.Rooms", "RoomID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomReservations", "RoomID", "dbo.Rooms");
            DropIndex("dbo.RoomReservations", new[] { "RoomID" });
            AlterColumn("dbo.RoomReservations", "RoomID", c => c.Int());
            RenameColumn(table: "dbo.RoomReservations", name: "RoomID", newName: "Rooms_RoomID");
            CreateIndex("dbo.RoomReservations", "Rooms_RoomID");
            AddForeignKey("dbo.RoomReservations", "Rooms_RoomID", "dbo.Rooms", "RoomID");
        }
    }
}

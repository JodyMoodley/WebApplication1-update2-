namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomupdatvgcg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomReservations", "Bill", c => c.Double());
            AlterColumn("dbo.RoomReservations", "ACheckIn", c => c.DateTime());
            AlterColumn("dbo.RoomReservations", "ACheckOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomReservations", "ACheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoomReservations", "ACheckIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoomReservations", "Bill", c => c.Double(nullable: false));
        }
    }
}

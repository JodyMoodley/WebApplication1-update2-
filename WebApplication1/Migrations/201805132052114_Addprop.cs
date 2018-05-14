namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomReservations", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomReservations", "UserID");
        }
    }
}

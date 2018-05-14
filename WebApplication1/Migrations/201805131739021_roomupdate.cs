namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "UserName", c => c.String());
            AddColumn("dbo.Rooms", "CheckInDate", c => c.DateTime());
            AddColumn("dbo.Rooms", "CheckOutDate", c => c.DateTime());
            AddColumn("dbo.Rooms", "NONights", c => c.Double());
            AddColumn("dbo.Rooms", "ApplicationUsers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rooms", "ApplicationUsers_Id");
            AddForeignKey("dbo.Rooms", "ApplicationUsers_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Rooms", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Price", c => c.Double(nullable: false));
            DropForeignKey("dbo.Rooms", "ApplicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "ApplicationUsers_Id" });
            DropColumn("dbo.Rooms", "ApplicationUsers_Id");
            DropColumn("dbo.Rooms", "NONights");
            DropColumn("dbo.Rooms", "CheckOutDate");
            DropColumn("dbo.Rooms", "CheckInDate");
            DropColumn("dbo.Rooms", "UserName");
        }
    }
}

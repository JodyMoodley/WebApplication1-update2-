namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbiisis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "RoomType", c => c.String(maxLength: 35));
            AlterColumn("dbo.Rooms", "BedSize", c => c.String(maxLength: 35));
            AlterColumn("dbo.Venues", "VenueName", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Venues", "VenueAddress", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Suburbs", "SuburbName", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Provinces", "ProvinceName", c => c.String(nullable: false, maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Provinces", "ProvinceName", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.Suburbs", "SuburbName", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "VenueAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "VenueName", c => c.String(nullable: false));
            AlterColumn("dbo.Rooms", "BedSize", c => c.String());
            AlterColumn("dbo.Rooms", "RoomType", c => c.String());
        }
    }
}

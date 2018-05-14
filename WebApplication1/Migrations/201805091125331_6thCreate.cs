namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6thCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomPrice = c.Double(nullable: false),
                        RoomType = c.String(),
                        BedSize = c.String(),
                        Status = c.Boolean(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "VenueID", "dbo.Venues");
            DropIndex("dbo.Rooms", new[] { "VenueID" });
            DropTable("dbo.Rooms");
        }
    }
}

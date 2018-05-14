namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5thCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(nullable: false),
                        SuburbID = c.Int(nullable: false),
                        VenueAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VenueID)
                .ForeignKey("dbo.Suburbs", t => t.SuburbID, cascadeDelete: true)
                .Index(t => t.SuburbID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "SuburbID", "dbo.Suburbs");
            DropIndex("dbo.Venues", new[] { "SuburbID" });
            DropTable("dbo.Venues");
        }
    }
}

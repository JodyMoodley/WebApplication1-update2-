namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        ProvinceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Provinces", t => t.ProvinceID, cascadeDelete: true)
                .Index(t => t.ProvinceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "ProvinceID", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceID" });
            DropTable("dbo.Cities");
        }
    }
}

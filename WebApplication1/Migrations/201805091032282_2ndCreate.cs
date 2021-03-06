namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Provinces");
        }
    }
}

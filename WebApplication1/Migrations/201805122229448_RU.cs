namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RU : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "NONight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "NONight", c => c.Int(nullable: false));
        }
    }
}

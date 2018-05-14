namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rstatusupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "bookingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "bookingStatus");
        }
    }
}

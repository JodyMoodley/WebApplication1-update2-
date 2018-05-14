namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "CheckInDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "CheckedInDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "CheckedInDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "CheckInDate");
        }
    }
}

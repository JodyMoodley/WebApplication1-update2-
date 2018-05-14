namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AddColumn("dbo.Reservations", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Reservations", "TPirce", c => c.Double(nullable: false));
            AddColumn("dbo.Reservations", "CheckOutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "NONight", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Reservations", "id");
            DropColumn("dbo.Reservations", "ResevationID");
            DropColumn("dbo.Reservations", "CheckedOutDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "CheckedOutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "ResevationID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Reservations");
            DropColumn("dbo.Reservations", "NONight");
            DropColumn("dbo.Reservations", "CheckOutDate");
            DropColumn("dbo.Reservations", "TPirce");
            DropColumn("dbo.Reservations", "id");
            AddPrimaryKey("dbo.Reservations", "ResevationID");
        }
    }
}

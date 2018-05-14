namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            AddColumn("dbo.Reservations", "UserName", c => c.String());
            AddColumn("dbo.Rooms", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Reservations", "ResevationID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reservations", "ResevationID");
            DropColumn("dbo.Reservations", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Reservations", "ResevationID", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "Price");
            DropColumn("dbo.Reservations", "UserName");
            AddPrimaryKey("dbo.Reservations", "id");
        }
    }
}

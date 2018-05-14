namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "forRef", c => c.String());
            AddColumn("dbo.Reservations", "refNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "refNo");
            DropColumn("dbo.Reservations", "forRef");
        }
    }
}

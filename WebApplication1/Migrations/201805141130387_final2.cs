namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "forRef");
            DropColumn("dbo.Reservations", "refNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "refNo", c => c.String());
            AddColumn("dbo.Reservations", "forRef", c => c.String());
        }
    }
}

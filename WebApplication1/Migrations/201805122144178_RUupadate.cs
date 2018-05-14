namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RUupadate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "UserID");
        }
    }
}

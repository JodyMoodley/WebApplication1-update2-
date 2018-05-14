namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechangek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomReservations", "Bill", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomReservations", "Bill", c => c.Double(nullable: false));
        }
    }
}

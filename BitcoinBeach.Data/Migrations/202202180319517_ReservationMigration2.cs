namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservation", "OwnerId");
        }
    }
}

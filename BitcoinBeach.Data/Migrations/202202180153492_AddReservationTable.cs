namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        ReservationStartDate = c.DateTime(nullable: false),
                        ReservationEndDate = c.DateTime(nullable: false),
                        ProfileId_ProfileId = c.Int(),
                        UnitId_UnitId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Profile", t => t.ProfileId_ProfileId)
                .ForeignKey("dbo.Unit", t => t.UnitId_UnitId)
                .Index(t => t.ProfileId_ProfileId)
                .Index(t => t.UnitId_UnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "UnitId_UnitId", "dbo.Unit");
            DropForeignKey("dbo.Reservation", "ProfileId_ProfileId", "dbo.Profile");
            DropIndex("dbo.Reservation", new[] { "UnitId_UnitId" });
            DropIndex("dbo.Reservation", new[] { "ProfileId_ProfileId" });
            DropTable("dbo.Reservation");
        }
    }
}

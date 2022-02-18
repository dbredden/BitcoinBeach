namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReservationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profile", "ProfileType_id", "dbo.ProfileType");
            DropForeignKey("dbo.Reservation", "ProfileId_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Reservation", "UnitId_UnitId", "dbo.Unit");
            DropIndex("dbo.Profile", new[] { "ProfileType_id" });
            DropIndex("dbo.Reservation", new[] { "ProfileId_ProfileId" });
            DropIndex("dbo.Reservation", new[] { "UnitId_UnitId" });
            RenameColumn(table: "dbo.Reservation", name: "ProfileId_ProfileId", newName: "ProfileId");
            RenameColumn(table: "dbo.Reservation", name: "UnitId_UnitId", newName: "UnitId");
            AddColumn("dbo.Profile", "ProfileType_type", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservation", "ProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservation", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservation", "ProfileId");
            CreateIndex("dbo.Reservation", "UnitId");
            AddForeignKey("dbo.Reservation", "ProfileId", "dbo.Profile", "ProfileId", cascadeDelete: true);
            AddForeignKey("dbo.Reservation", "UnitId", "dbo.Unit", "UnitId", cascadeDelete: true);
            DropColumn("dbo.Profile", "ProfileType_id");
            DropTable("dbo.ProfileType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProfileType",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Profile", "ProfileType_id", c => c.Byte());
            DropForeignKey("dbo.Reservation", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Reservation", "ProfileId", "dbo.Profile");
            DropIndex("dbo.Reservation", new[] { "UnitId" });
            DropIndex("dbo.Reservation", new[] { "ProfileId" });
            AlterColumn("dbo.Reservation", "UnitId", c => c.Int());
            AlterColumn("dbo.Reservation", "ProfileId", c => c.Int());
            DropColumn("dbo.Profile", "ProfileType_type");
            RenameColumn(table: "dbo.Reservation", name: "UnitId", newName: "UnitId_UnitId");
            RenameColumn(table: "dbo.Reservation", name: "ProfileId", newName: "ProfileId_ProfileId");
            CreateIndex("dbo.Reservation", "UnitId_UnitId");
            CreateIndex("dbo.Reservation", "ProfileId_ProfileId");
            CreateIndex("dbo.Profile", "ProfileType_id");
            AddForeignKey("dbo.Reservation", "UnitId_UnitId", "dbo.Unit", "UnitId");
            AddForeignKey("dbo.Reservation", "ProfileId_ProfileId", "dbo.Profile", "ProfileId");
            AddForeignKey("dbo.Profile", "ProfileType_id", "dbo.ProfileType", "id");
        }
    }
}

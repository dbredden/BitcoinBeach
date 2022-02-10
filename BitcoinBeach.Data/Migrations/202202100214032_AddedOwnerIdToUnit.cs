namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwnerIdToUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Unit", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Unit", "OwnerId");
        }
    }
}

namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Profile", new[] { "ProfileType_Id" });
            AddColumn("dbo.ProfileType", "type", c => c.Int(nullable: false));
            CreateIndex("dbo.Profile", "ProfileType_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Profile", new[] { "ProfileType_id" });
            DropColumn("dbo.ProfileType", "type");
            CreateIndex("dbo.Profile", "ProfileType_Id");
        }
    }
}

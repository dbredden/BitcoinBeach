namespace BitcoinBeach.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ProfileType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.ProfileType", t => t.ProfileType_Id)
                .Index(t => t.ProfileType_Id);
            
            CreateTable(
                "dbo.ProfileType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profile", "ProfileType_Id", "dbo.ProfileType");
            DropIndex("dbo.Profile", new[] { "ProfileType_Id" });
            DropTable("dbo.ProfileType");
            DropTable("dbo.Profile");
        }
    }
}

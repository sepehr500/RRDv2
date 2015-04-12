namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomIDChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ReviewId", c => c.Int(nullable: false));
        }
    }
}

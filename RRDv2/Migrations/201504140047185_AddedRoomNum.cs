namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoomNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "RoomNum");
        }
    }
}

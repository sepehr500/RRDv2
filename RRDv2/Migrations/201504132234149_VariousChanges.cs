namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VariousChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomLength", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "RoomSize", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "ElevatorDistance", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "ConnectingRoom", c => c.Boolean(nullable: false));
            DropColumn("dbo.Rooms", "RoomNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomNum", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "ConnectingRoom");
            DropColumn("dbo.Rooms", "ElevatorDistance");
            DropColumn("dbo.Rooms", "RoomSize");
            DropColumn("dbo.Rooms", "RoomLength");
        }
    }
}

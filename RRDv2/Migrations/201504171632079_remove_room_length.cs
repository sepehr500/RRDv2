namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_room_length : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "RoomLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomLength", c => c.Int(nullable: false));
        }
    }
}

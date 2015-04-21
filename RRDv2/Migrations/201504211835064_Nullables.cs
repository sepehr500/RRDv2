namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "RoomLength", c => c.Int());
            AlterColumn("dbo.Rooms", "RoomSize", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomSize", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "RoomLength", c => c.Int(nullable: false));
        }
    }
}

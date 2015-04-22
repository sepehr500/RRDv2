namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bed_type_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int());
            AlterColumn("dbo.Rooms", "RoomSize", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id");
            DropColumn("dbo.Rooms", "RoomLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomLength", c => c.Int());
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "RoomSize", c => c.Int());
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
        }
    }
}

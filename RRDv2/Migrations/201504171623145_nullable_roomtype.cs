namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_roomtype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int());
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
        }
    }
}

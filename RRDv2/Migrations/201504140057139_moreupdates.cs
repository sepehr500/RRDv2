namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreupdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoomTypes", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomTypes", "RoomId", c => c.Int(nullable: false));
        }
    }
}

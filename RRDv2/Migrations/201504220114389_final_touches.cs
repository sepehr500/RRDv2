namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_touches : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "BedSize", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "BedSize", c => c.Int(nullable: false));
        }
    }
}

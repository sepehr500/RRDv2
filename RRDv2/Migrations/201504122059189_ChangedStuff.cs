namespace RRDv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Floors", "FloorNum", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Stars", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Stars");
            DropColumn("dbo.Floors", "FloorNum");
        }
    }
}

namespace MyAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Restaurants", new[] { "timing_id" });
            CreateIndex("dbo.Restaurants", "Timing_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Restaurants", new[] { "Timing_id" });
            CreateIndex("dbo.Restaurants", "timing_id");
        }
    }
}

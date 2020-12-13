namespace MyTrips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Id", "dbo.Trips");
            DropIndex("dbo.Videos", new[] { "Id" });
            AddColumn("dbo.Videos", "TripId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videos", "TripId");
            AddForeignKey("dbo.Videos", "TripId", "dbo.Trips", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "TripId", "dbo.Trips");
            DropIndex("dbo.Videos", new[] { "TripId" });
            DropColumn("dbo.Videos", "TripId");
            CreateIndex("dbo.Videos", "Id");
            AddForeignKey("dbo.Videos", "Id", "dbo.Trips", "Id");
        }
    }
}

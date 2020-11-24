namespace MyTrips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        Kilometers = c.Int(nullable: false),
                        LaunchSite = c.String(),
                        Destination = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VideoPath = c.String(),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Photos", "TripId", "dbo.Trips");
            DropIndex("dbo.Videos", new[] { "TripId" });
            DropIndex("dbo.Photos", new[] { "TripId" });
            DropTable("dbo.Videos");
            DropTable("dbo.Trips");
            DropTable("dbo.Photos");
        }
    }
}

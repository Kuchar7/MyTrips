namespace MyTrips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trips", "Kilometers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trips", "Kilometers", c => c.Int(nullable: false));
        }
    }
}

namespace MyTrips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "ImagePath", c => c.Int(nullable: false));
        }
    }
}

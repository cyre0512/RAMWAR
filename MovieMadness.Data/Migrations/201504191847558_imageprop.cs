namespace MovieMadness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Thumbnail");
        }
    }
}

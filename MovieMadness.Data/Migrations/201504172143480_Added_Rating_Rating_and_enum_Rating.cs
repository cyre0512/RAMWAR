namespace MovieMadness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Rating_Rating_and_enum_Rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Rating");
        }
    }
}

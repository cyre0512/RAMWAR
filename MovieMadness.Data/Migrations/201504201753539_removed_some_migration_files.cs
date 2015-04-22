namespace MovieMadness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_some_migration_files : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieActors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "Actor_ActorId", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "Movie_MovieId" });
            DropIndex("dbo.MovieActors", new[] { "Actor_ActorId" });
            CreateTable(
                "dbo.Movie_Actors",
                c => new
                    {
                        MovieActorsId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieActorsId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            DropColumn("dbo.Movies", "ActorId");
            DropTable("dbo.MovieActors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Actor_ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Actor_ActorId });
            
            AddColumn("dbo.Movies", "ActorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movie_Actors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movie_Actors", "ActorId", "dbo.Actors");
            DropIndex("dbo.Movie_Actors", new[] { "ActorId" });
            DropIndex("dbo.Movie_Actors", new[] { "MovieId" });
            DropTable("dbo.Movie_Actors");
            CreateIndex("dbo.MovieActors", "Actor_ActorId");
            CreateIndex("dbo.MovieActors", "Movie_MovieId");
            AddForeignKey("dbo.MovieActors", "Actor_ActorId", "dbo.Actors", "ActorId", cascadeDelete: true);
            AddForeignKey("dbo.MovieActors", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}

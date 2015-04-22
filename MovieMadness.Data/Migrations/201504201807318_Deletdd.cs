namespace MovieMadness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie_ActorsActor", "Movie_Actors_Movie_ActorsId", "dbo.Movie_Actors");
            DropForeignKey("dbo.Movie_ActorsActor", "Actor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.MovieMovie_Actors", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieMovie_Actors", "Movie_Actors_Movie_ActorsId", "dbo.Movie_Actors");
            DropIndex("dbo.Movie_ActorsActor", new[] { "Movie_Actors_Movie_ActorsId" });
            DropIndex("dbo.Movie_ActorsActor", new[] { "Actor_ActorId" });
            DropIndex("dbo.MovieMovie_Actors", new[] { "Movie_MovieId" });
            DropIndex("dbo.MovieMovie_Actors", new[] { "Movie_Actors_Movie_ActorsId" });
            DropPrimaryKey("dbo.Movie_Actors");
            AddColumn("dbo.Movie_Actors", "MovieActorsId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Movie_Actors", "MovieActorsId");
            CreateIndex("dbo.Movie_Actors", "MovieId");
            CreateIndex("dbo.Movie_Actors", "ActorId");
            AddForeignKey("dbo.Movie_Actors", "ActorId", "dbo.Actors", "ActorId", cascadeDelete: true);
            AddForeignKey("dbo.Movie_Actors", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            DropColumn("dbo.Movie_Actors", "Movie_ActorsId");
            DropTable("dbo.Movie_ActorsActor");
            DropTable("dbo.MovieMovie_Actors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieMovie_Actors",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Movie_Actors_Movie_ActorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Movie_Actors_Movie_ActorsId });
            
            CreateTable(
                "dbo.Movie_ActorsActor",
                c => new
                    {
                        Movie_Actors_Movie_ActorsId = c.Int(nullable: false),
                        Actor_ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Actors_Movie_ActorsId, t.Actor_ActorId });
            
            AddColumn("dbo.Movie_Actors", "Movie_ActorsId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Movie_Actors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movie_Actors", "ActorId", "dbo.Actors");
            DropIndex("dbo.Movie_Actors", new[] { "ActorId" });
            DropIndex("dbo.Movie_Actors", new[] { "MovieId" });
            DropPrimaryKey("dbo.Movie_Actors");
            DropColumn("dbo.Movie_Actors", "MovieActorsId");
            AddPrimaryKey("dbo.Movie_Actors", "Movie_ActorsId");
            CreateIndex("dbo.MovieMovie_Actors", "Movie_Actors_Movie_ActorsId");
            CreateIndex("dbo.MovieMovie_Actors", "Movie_MovieId");
            CreateIndex("dbo.Movie_ActorsActor", "Actor_ActorId");
            CreateIndex("dbo.Movie_ActorsActor", "Movie_Actors_Movie_ActorsId");
            AddForeignKey("dbo.MovieMovie_Actors", "Movie_Actors_Movie_ActorsId", "dbo.Movie_Actors", "Movie_ActorsId", cascadeDelete: true);
            AddForeignKey("dbo.MovieMovie_Actors", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.Movie_ActorsActor", "Actor_ActorId", "dbo.Actors", "ActorId", cascadeDelete: true);
            AddForeignKey("dbo.Movie_ActorsActor", "Movie_Actors_Movie_ActorsId", "dbo.Movie_Actors", "Movie_ActorsId", cascadeDelete: true);
        }
    }
}

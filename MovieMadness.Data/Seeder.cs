using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieMadness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace MovieMadness.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool roles = true, bool users = true, bool movies = true, bool actors = true, bool movie_actors = true, bool reviews = true)
        {
            if(roles) SeedRoles(db);
            if (users) SeedUsers(db);
            if (movies) SeedMovies(db);
            if (actors) SeedActors(db);
            if (movie_actors) SeedMovieActors(db);
            if (reviews) SeedReviews(db);
        }

        private static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            manager.Create(new IdentityRole()
            {
                Name = "User"
            });

            manager.Create(new IdentityRole() { Name = "Admin" });
        }

        private static void SeedUsers(ApplicationDbContext db) 
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            if (!db.Users.Any(x => x.UserName == "test@test.com")) 
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "test@test.com",
                    Email = "test@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
            if(!db.Users.Any(x => x.UserName == "admin@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "Admin");
            }
            }

            private static void SeedMovies(ApplicationDbContext db)
            {
                string testId = db.Users.FirstOrDefault( x => x.UserName == "test@test.com").Id;
                string adminId = db.Users.FirstOrDefault( x => x.UserName == "admin@test.com").Id;

                db.Movies.AddOrUpdate(x => x.MovieId,
                    new Movie() { MovieId = 1, Title = "Fight Club", Year = 1999, Genre = Genre.Drama, Rating = Rating.R, Thumbnail = "http://www.movieboozer.com/wp-content/uploads/2013/03/fight-club-poster.jpg" },
                    new Movie() { MovieId = 2, Title = "The Dark Knight", Year = 2008, Genre = Genre.Thriller, Rating = Rating.PG13, Thumbnail = "http://ia.media-imdb.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_SX214_AL_.jpg" },
                    new Movie() { MovieId = 3, Title = "Superbad", Year = 2007, Genre = Genre.Comedy, Rating = Rating.R, Thumbnail = "http://ia.media-imdb.com/images/M/MV5BMTc0NjIyMjA2OF5BMl5BanBnXkFtZTcwMzIxNDE1MQ@@._V1_SX640_SY720_.jpg" },
                    new Movie() { MovieId = 4, Title = "Human Centipede", Year = 2009, Genre = Genre.Horror, Rating = Rating.R, Thumbnail = "http://upload.wikimedia.org/wikipedia/en/f/f1/Human-Centiped-poster.jpg" },
                    new Movie() { MovieId = 5, Title = "Interstellar", Year = 2014, Genre = Genre.SciFi, Rating = Rating.PG13, Thumbnail = "http://ia.media-imdb.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_SX640_SY720_.jpg" }
                );
              
            }
        
            private static void SeedActors(ApplicationDbContext db)
            {
 	             db.Actors.AddOrUpdate(x=>x.ActorId,    
                     new Actor() { ActorId = 1, Name = "Brad Pitt" },
                     new Actor() { ActorId = 2, Name = "Edward Norton" },
                     new Actor() { ActorId = 3, Name = "Helena Bonham" },
                     new Actor() { ActorId = 4, Name = "Heath Ledger" },
                     new Actor() { ActorId = 5, Name = "Christan Bale" },
                     new Actor() { ActorId = 6, Name = "Michael Caine" },
                     new Actor() { ActorId = 7, Name = "Morgan Freeman" },
                     new Actor() { ActorId = 8, Name = "Garey Oldman" },
                     new Actor() { ActorId = 9, Name = "Jonah Hill" },
                     new Actor() { ActorId = 10, Name = "Seth Rogan" },
                     new Actor() { ActorId = 11, Name = "Michael Cera" },
                     new Actor() { ActorId = 12, Name = "Emma Stone" },
                     new Actor() { ActorId = 13, Name = "Dieter Laser" },
                     new Actor() { ActorId = 14, Name = "Ashley Williams" },
                     new Actor() { ActorId = 15, Name = "Ashlynn Yennie" },
                     new Actor() { ActorId = 16, Name = "Akihiro Kitamura" },
                     new Actor() { ActorId = 17, Name = "Matthew McConaughey" },
                     new Actor() { ActorId = 18, Name = "Anne Hathaway" },
                     new Actor() { ActorId = 19, Name = "Jessica Chastain" },
                     new Actor() { ActorId = 20, Name = "Mackenzie Foy" }
                 );
            }

            private static void SeedMovieActors(ApplicationDbContext db)
            {
                db.MovieActors.AddOrUpdate(x => x.MovieActorsId,
                    new Movie_Actors() { MovieActorsId = 1, ActorId = 1, MovieId = 1 },
                    new Movie_Actors() { MovieActorsId = 2, ActorId = 2, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 3, ActorId = 3, MovieId = 1 },
                    new Movie_Actors() { MovieActorsId = 4, ActorId = 4, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 5, ActorId = 5, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 6, ActorId = 6, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 7, ActorId = 7, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 8, ActorId = 8, MovieId = 2 },
                    new Movie_Actors() { MovieActorsId = 9, ActorId = 9, MovieId = 3 },
                    new Movie_Actors() { MovieActorsId = 10, ActorId = 10, MovieId = 3 },
                    new Movie_Actors() { MovieActorsId = 11, ActorId = 11, MovieId = 3 },
                    new Movie_Actors() { MovieActorsId = 12, ActorId = 12, MovieId = 3 },
                    new Movie_Actors() { MovieActorsId = 13, ActorId = 13, MovieId = 4 },
                    new Movie_Actors() { MovieActorsId = 14, ActorId = 14, MovieId = 4 },
                    new Movie_Actors() { MovieActorsId = 15, ActorId = 15, MovieId = 4 },
                    new Movie_Actors() { MovieActorsId = 16, ActorId = 16, MovieId = 4 },
                    new Movie_Actors() { MovieActorsId = 17, ActorId = 17, MovieId = 5 },
                    new Movie_Actors() { MovieActorsId = 18, ActorId = 18, MovieId = 5 },
                    new Movie_Actors() { MovieActorsId = 19, ActorId = 19, MovieId = 5 },
                    new Movie_Actors() { MovieActorsId = 20, ActorId = 20, MovieId = 5 },
                    new Movie_Actors() { MovieActorsId = 21, ActorId = 6, MovieId = 5 }
                );
            }

            private static void SeedReviews(ApplicationDbContext db)
            {
                db.Reviews.AddOrUpdate(x => x.ReviewId,
                   new Review() { ReviewId = 1, Post = "Review1", DatePosted = DateTime.Now, MovieId = 1, Rating = 1 },
                   new Review() { ReviewId = 2, Post = "Review2", DatePosted = DateTime.Now, MovieId = 2, Rating = 2 },
                   new Review() { ReviewId = 3, Post = "Review3", DatePosted = DateTime.Now, MovieId = 3, Rating = 3 },
                   new Review() { ReviewId = 4, Post = "Review4", DatePosted = DateTime.Now, MovieId = 4, Rating = 4 },
                   new Review() { ReviewId = 5, Post = "Review5", DatePosted = DateTime.Now, MovieId = 5, Rating = 5 }
                );
            }


            
        }
}


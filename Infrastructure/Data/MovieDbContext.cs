using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieDbContext(DbContextOptions options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.CastId });
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);
            modelBuilder.Entity<MovieCast>()
               .HasOne(mc => mc.Movie)
               .WithMany(m => m.MovieCasts)
               .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<Trailer>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Trailers)
                .HasForeignKey(t => t.MovieId);

            modelBuilder.Entity<Favorite>().HasKey(f => new { f.MovieId, f.UserId });
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<Review>().HasKey(f => new { f.MovieId, f.UserId });
            modelBuilder.Entity<Review>()
                .HasOne(f => f.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(p => p.MovieId);

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.RoleId, ur.UserId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}

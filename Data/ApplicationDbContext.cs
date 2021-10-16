using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CinemaFinalMVC.Models;

namespace CinemaFinalMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CinemaFinalMVC.Models.Country> Country { get; set; }
        public DbSet<CinemaFinalMVC.Models.Genre> Genre { get; set; }
        public DbSet<CinemaFinalMVC.Models.Profession> Profession { get; set; }
        public DbSet<CinemaFinalMVC.Models.Celebrity> Celebrity { get; set; }
        public DbSet<CinemaFinalMVC.Models.CelebrityProfession> CelebrityProfession { get; set; }
        public DbSet<CinemaFinalMVC.Models.Movie> Movie { get; set; }
        public DbSet<CinemaFinalMVC.Models.MovieGenre> MovieGenre { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
        
        public DbSet<CinemaFinalMVC.Models.MovieCelebrity> MovieCelebrity { get; set; }
        
        
        
    }
}




//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>();
//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>();
//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>();
//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUserToken<string>>();
//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUser<string>>();
//builder.Ignore<Microsoft.AspNetCore.Identity.IdentityUser>();

/*
builder.Entity<Comment>()
.HasOne(b => b.IdentityUser);

builder.Entity<Celebrity>()
.HasMany(b => b.Comments)
.WithOne(e => e.Celebrity);
builder.Entity<Movie>()
.HasMany(b => b.Comments)
.WithOne(e => e.Movie);

*/
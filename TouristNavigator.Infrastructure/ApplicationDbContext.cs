using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public ApplicationDbContext()
        {
                
        }

        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<PlaceCategory> PlacesCategories { get; set; }
        DbSet<UserPreferences> UserPreferences { get; set; }
        DbSet<CategoryIcon> CategoryIcons { get; set; }
        DbSet<PlacePhoto> PlacesPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaceCategory>().HasKey(pc => new { pc.PlaceId, pc.CategoryId });
            modelBuilder.Entity<UserPreferences>().HasKey(up => new { up.UserId, up.CategoryId });

            modelBuilder.Entity<Category>().HasOne(c => c.Icon).WithOne(i => i.Category).HasForeignKey<CategoryIcon>(i => i.CategoryId);

            modelBuilder.Entity<Place>().HasMany(p => p.Categories).WithOne(c => c.Place).HasForeignKey(x => x.PlaceId);
            modelBuilder.Entity<Category>().HasMany(c => c.RelatedPlaces).WithOne(p => p.Category).HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Place>().OwnsOne(p => p.Adress);
           
        }
    }
}

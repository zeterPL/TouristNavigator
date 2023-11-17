using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure.Repositories
{
    public class PlaceRepository : BaseRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(ApplicationDbContext context) : base(context) { }

        public async Task AddCategoryToPlaceAsync(PlaceCategory category)
        {
            await _context.Set<PlaceCategory>().AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfPlaceIsFavourite(int placeId, int userId)
        {
            var fav = _context.Set<FavouriteUserPlace>().Where(f => f.UserId == userId && f.PlaceId == placeId);
            if (fav.Count() > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<List<Category>> GetAllCategoriesAsync(int id)
        {
            var place = await _context.Set<Place>().Include(p => p.Categories)
                .ThenInclude(pc => pc.Category).ThenInclude(c => c.Icon).FirstOrDefaultAsync(p => p.Id == id);

            var categories = place.Categories.Select(pc => pc.Category).ToList();
            return categories;
           
            
        }

        public async Task<List<Place>> GetAllWithPhoto()
        {
            var places = await _context.Set<Place>().Include(p => p.PlacePhoto).ToListAsync();
            return places;
        }

        public async Task SetPlaceAsFavourite(FavouriteUserPlace favouritePlace)
        {
            await _context.Set<FavouriteUserPlace>().AddAsync(favouritePlace);
            await _context.SaveChangesAsync();

        }
    }
}

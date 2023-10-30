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

        public async Task<List<Category>> GetAllCategoriesAsync(int id)
        {
            var place = await _context.Set<Place>().Include(p => p.Categories)
                .ThenInclude(pc => pc.Category).FirstOrDefaultAsync(p => p.Id == id);

            var categories = place.Categories.Select(pc => pc.Category).ToList();
            return categories;
           
            
        }
    }
}

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
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task AddUserPreferenceAsync(UserPreferences preference)
        {
            await _context.Set<UserPreferences>().AddAsync(preference);    
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserPreference(int userId, int categoryId)
        {
            var pref = await _context.Set<UserPreferences>().Where(p => p.UserId == userId &&  p.CategoryId == categoryId).FirstOrDefaultAsync();
            _context.Set<UserPreferences>().Remove(pref);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Place>> GetUserPlacesAsync(int userId)
        {
            return await _context.Set<Place>().Where(p => p.OwnerId == userId).ToListAsync();
        }

        public async Task<List<Category>> GetUserPreferences(int userId)
        {
            var user = await _context.Set<ApplicationUser>().Include(u => u.UserPreferences)
                .ThenInclude(up => up.Category).ThenInclude(c => c.Icon).FirstOrDefaultAsync(u => u.Id == userId);

            var categories = user.UserPreferences.Select(pc => pc.Category).ToList();
            return categories;
        }
    }
}

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

        public async Task<List<Place>> GetUserPlacesAsync(int userId)
        {
            return await _context.Set<Place>().Where(p => p.OwnerId == userId).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<List<Place>> GetUserPlacesAsync(int userId);
        Task AddUserPreferenceAsync(UserPreferences preference);
        Task<List<Category>> GetUserPreferences(int userId);
        Task DeleteUserPreference(int  userId, int categoryId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApplicationUser> GetByIdAsync(int id);
        public Task<List<ApplicationUser>> GetAllAsync();
        public Task UpdateAsync(ApplicationUser user);
        public Task RemoveAsync(ApplicationUser user);
        public Task<List<PlaceDto>> GetUserPlacesAsync(int userId);
        public Task AddUserPreference(int userId, int categoryId);
        public Task<List<CategoryDto>> GetUserPreferences(int userId);
        public Task DeleteUserPreference(int userId, int categoryId);
    }
}

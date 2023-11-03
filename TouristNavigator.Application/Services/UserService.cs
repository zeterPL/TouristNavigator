using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UserService(IUserRepository userRepository, ICategoryRepository categoryRepository)
        { 
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public Task AddUserPreference(int userId, int categoryId)
        {
            var pref = new UserPreferences
            {
                UserId = userId,
                CategoryId = categoryId
            };
            return _userRepository.AddUserPreferenceAsync(pref);
        }

        public Task<List<ApplicationUser>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<ApplicationUser> GetByIdAsync(int id)
        {
            return _userRepository.GetAsync(id);
        }

        public Task<List<Place>> GetUserPlacesAsync(int userId)
        {
            return _userRepository.GetUserPlacesAsync(userId);
        }

        public async Task<List<CategoryDto>> GetUserPreferences(int userId)
        {
            var pref = await _userRepository.GetUserPreferences(userId);
            return pref.Select(p => p.toCategoryDto()).ToList();
        }

        public Task RemoveAsync(ApplicationUser user)
        {
            return _userRepository.DeleteAsync(user);
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            return _userRepository.UpdateAsync(user);
        }
    }
}

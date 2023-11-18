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
        private readonly IPlaceRepository _placeRepository;

        public UserService(IUserRepository userRepository, ICategoryRepository categoryRepository, IPlaceRepository placeRepository)
        { 
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _placeRepository = placeRepository;
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

        public Task DeleteUserPreference(int userId, int categoryId)
        {
            return _userRepository.DeleteUserPreference(userId, categoryId);
        }

        public Task<List<ApplicationUser>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<ApplicationUser> GetByIdAsync(int id)
        {
            return _userRepository.GetAsync(id);
        }

        public async Task<List<PlaceDto>> GetUserFavouritePlaces(int userId)
        {
            var fav = await _userRepository.GetUserFavouritePlaces(userId);
            return fav.Select(p => p.toPlaceDto()).ToList();
        }

        public async Task<List<PlaceDto>> GetUserPlacesAsync(int userId)
        {
            var places = await _placeRepository.GetAllWithPhoto();
            return places.Where(p => p.OwnerId == userId).Select(p => p.toPlaceDto()).ToList();
        }

        public async Task<List<CategoryDto>> GetUserPreferences(int userId)
        {
            var pref = await _userRepository.GetUserPreferences(userId);
            return pref.Select(p => p.toCategoryDto()).ToList();
        }

        public async Task<List<ReviewDto>> GetUserReviews(int userId)
        {
            var reviews = await _userRepository.GetUserReviews(userId);
            return reviews.Select(r => r.toReviewDto()).ToList();
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

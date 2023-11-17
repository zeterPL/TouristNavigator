using TouristNavigator.Application.Dto;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IPlaceService
    {
        public Task<List<PlaceDto>> GetAllAsync();

        public Task<Place> GetByIdAsync(int id);

        public Task RemoveAsync(int id);

        public Task UpdateAsync(PlaceDto place);

        public Task<int> CreateAsync(AddPlaceDto place);

        public Task<List<ReviewDto>> GetPlaceReviews(int id);

        public Task AddCategoryToPlace(int placeId, int categoryId);

        public Task<List<CategoryDto>> GetPlaceCategories(int id);

        public Task AddPhotoAsync(PlacePhotoDto dto, int placeId);

        public Task SetPlaceAsFavourite(int placeId, int userId);

        public Task<bool> CheckIfPlaceIsFavourite(int placeId, int userId);
    }
}
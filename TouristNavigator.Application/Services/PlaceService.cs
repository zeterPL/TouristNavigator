using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPlacePhotoRepository _photoRepository;

        public PlaceService(IPlaceRepository placeRepository, IReviewRepository reviewRepository, ICategoryRepository categoryRepository, IPlacePhotoRepository photoRepository)
        {
            _placeRepository = placeRepository;
            _reviewRepository = reviewRepository;
            _categoryRepository = categoryRepository;
            _photoRepository = photoRepository;
        }

        public Task AddCategoryToPlace(int placeId, int categoryId)
        {
            var placeCat = new PlaceCategory
            {
                PlaceId = placeId,
                CategoryId = categoryId
            };
            return _placeRepository.AddCategoryToPlaceAsync(placeCat);
        }

        public async Task<int> CreateAsync(AddPlaceDto place)
        {
            var p = new Place
            {
                Name = place.Name,
                Description = place.Description,
                Adress = place.Adress,
                Url = place.Url,
                OwnerId = place.OwnerId,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                Rating = 0.0
            };
          
            var createdPlace = await _placeRepository.AddAsync(p);

            if (place.Photo != null)
            {
                var photo = new PlacePhotoDto { Photo = place.Photo };
                await AddPhotoAsync(photo, createdPlace.Id);
            }
            return createdPlace.Id;

        }

        public async Task<List<PlaceDto>> GetAllAsync()
        {
            var places = await _placeRepository.GetAllWithPhoto();
            return places.Select(p => p.toPlaceDto()).ToList();
        }

        public Task<Place> GetByIdAsync(int id)
        {
            return _placeRepository.GetAsync(id);
        }

        public async Task<List<ReviewDto>> GetPlaceReviews(int id)
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Where(r => r.PlaceId == id).Select(r => r.toReviewDto()).ToList();
        }

        public async Task<List<CategoryDto>> GetPlaceCategories(int id)
        {
            var cat = await _placeRepository.GetAllCategoriesAsync(id);  
            return cat.Select(c => c.toCategoryDto()).ToList();
        }

        public async Task RemoveAsync(int id)
        {
            var entity =  _placeRepository.GetAsync(id).Result;
            await _placeRepository.DeleteAsync(entity);
        }

        public Task UpdateAsync(Place place)
        {
            return _placeRepository.UpdateAsync(place);
        }

        public Task AddPhotoAsync(PlacePhotoDto dto, int placeId)
        {
            PlacePhoto photo = new PlacePhoto
            {
                PlaceId = placeId,
                Photo = dto.Photo
            };

            return _photoRepository.AddAsync(photo);
        }
    }
}

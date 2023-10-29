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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IReviewRepository _reviewRepository;

        public PlaceService(IPlaceRepository placeRepository, IReviewRepository reviewRepository)
        {
            _placeRepository = placeRepository;
            _reviewRepository = reviewRepository;
        }

        public Task CreateAsync(Place place)
        {
            return _placeRepository.AddAsync(place);
        }

        public Task<List<Place>> GetAllAsync()
        {
            return _placeRepository.GetAllAsync();
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

        public async Task RemoveAsync(int id)
        {
            var entity =  _placeRepository.GetAsync(id).Result;
            await _placeRepository.DeleteAsync(entity);
        }

        public Task UpdateAsync(Place place)
        {
            return _placeRepository.UpdateAsync(place);
        }
    }
}

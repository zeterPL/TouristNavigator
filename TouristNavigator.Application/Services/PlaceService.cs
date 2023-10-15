using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
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

        public Task RemoveAsync(Place place)
        {
            return _placeRepository.DeleteAsync(place);
        }

        public Task UpdateAsync(Place place)
        {
            return _placeRepository.UpdateAsync(place);
        }
    }
}

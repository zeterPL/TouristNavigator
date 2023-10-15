using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IPlaceService
    {
        public Task<List<Place>> GetAllAsync();
        public Task<Place> GetByIdAsync(int id);
        public Task RemoveAsync(Place place);
        public Task UpdateAsync(Place place);
        public Task CreateAsync(Place place);
        
    }
}

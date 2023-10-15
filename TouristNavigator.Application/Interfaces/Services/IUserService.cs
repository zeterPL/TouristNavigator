using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ApplicationUser> GetByIdAsync(int id);
        public Task<List<ApplicationUser>> GetAllAsync();
        public Task UpdateAsync(ApplicationUser user);
        public Task RemoveAsync(ApplicationUser user);
        public Task<List<Place>> GetUserPlacesAsync(int userId);
    }
}

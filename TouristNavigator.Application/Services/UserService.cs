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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
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

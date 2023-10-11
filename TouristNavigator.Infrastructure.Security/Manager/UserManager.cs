using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Security.Interfaces;
using TouristNavigator.Application.Security.Models;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure.Security.Manager
{
    public class UserManager : IUserManager<ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserManagerResult> CreateAsync(ApplicationUser user)
        {
            _userRepository.AddAsync(user);
            return Task.FromResult(UserManagerResult.Success);
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var user = _userRepository.GetAllAsync().Result
                .Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();

            return Task.FromResult(user);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = _userRepository.GetAllAsync().Result
                .Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();

            return Task.FromResult(user);
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var users = _userRepository.GetAllAsync().Result;
            return Task.FromResult(users);
        }

        public Task<IList<Claim>> GetClaimsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

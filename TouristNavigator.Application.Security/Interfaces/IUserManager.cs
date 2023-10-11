using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Security.Models;

namespace TouristNavigator.Application.Security.Interfaces
{
    public interface IUserManager<TUser> where TUser : class
    {
        Task<IEnumerable<TUser>> GetAllAsync();
        Task<IList<string>> GetRolesAsync();
        Task<IList<Claim>> GetClaimsAsync();
        Task<TUser> FindByEmailAsync(string email);
        Task<TUser> FindByNameAsync(string userName);
        Task<UserManagerResult> CreateAsync(TUser user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Security.Models;

namespace TouristNavigator.Application.Security.Interfaces
{
    public interface ISignInManager<TUser> where TUser : class
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent);
    }
}

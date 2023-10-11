using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Security.Interfaces;
using TouristNavigator.Application.Security.Models;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure.Security.Manager
{
    public class SignInManager : ISignInManager<ApplicationUser>
    {
        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent)
        {
            //dodać sprawdzanie hasła
            if(password == "12345")
            {
                return Task.FromResult(SignInResult.Success);
            }
            else
            {
                return Task.FromResult(SignInResult.Fail);
            }
        }
    }
}

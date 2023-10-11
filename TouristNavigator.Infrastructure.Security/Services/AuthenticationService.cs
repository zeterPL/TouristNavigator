using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Security.Interfaces;
using TouristNavigator.Application.Security.Models;

namespace TouristNavigator.Infrastructure.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

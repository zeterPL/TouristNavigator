using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TouristNavigator.Application.Security.Interfaces;
using TouristNavigator.Application.Security.Models;

namespace TouristNavigator.API.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;


        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Authenticate", Name = "Authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationRequest newRequest = new AuthenticationRequest();
            try
            {
                newRequest.Email = JsonSerializer.Deserialize<string>(request.Email);
                newRequest.Password = JsonSerializer.Deserialize<string>(request.Password);
            }catch (Exception ex)
            {
                newRequest = request;
            }
           

            return Ok(await _authenticationService.AuthenticateAsync(newRequest));
        }

        [HttpPost("Register", Name = "Register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            RegistrationRequest newRequest = new RegistrationRequest();
            try
            {
                newRequest = request;
                newRequest.UserName = JsonSerializer.Deserialize<string>(request.UserName);
                newRequest.Email = JsonSerializer.Deserialize<string>(request.Email);
                newRequest.Password = JsonSerializer.Deserialize<string>(request.Password);
            }
            catch (Exception ex)
            {
                newRequest = request;
            }

            return Ok(await _authenticationService.RegisterAsync(newRequest));
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.API.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet("getbyid/{id}", Name = "GetUserById")]
        public async Task<ActionResult<ApplicationUser>> getUserById(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet("getall", Name = "GetAllUsers")]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        
        [HttpPut("updateuser", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser(UpdateUserDto user)
        {
            UpdateUserDto newRequest = new UpdateUserDto();
            try
            {
                newRequest = user;
                newRequest.UserName = JsonSerializer.Deserialize<string>(user.UserName);
                newRequest.FirstName = JsonSerializer.Deserialize<string>(user.FirstName);
                newRequest.LastName = JsonSerializer.Deserialize<string>(user.LastName);
                newRequest.Email = JsonSerializer.Deserialize<string>(user.Email);
               
            }
            catch (Exception ex)
            {
                newRequest = user;
            }


            await _userService.UpdateAsync(newRequest);
            return Ok();
        }

        [HttpDelete("removeuser", Name = "RemoveUser")]
        public async Task<ActionResult> RemoveUser(ApplicationUser user)
        {
            await _userService.RemoveAsync(user);
            return Ok();
        }

        [HttpGet("places/{userId}", Name = "GetUserPlaces")]
        public async Task<ActionResult<List<PlaceDto>>> GetUserPlaces(int userId)
        {
            return Ok(await _userService.GetUserPlacesAsync(userId));
        }

        [HttpPost("preference/{userId}/{categoryId}", Name = "AddUserPreference")]
        public async Task<ActionResult> AddUserPreference(int userId, int categoryId)
        {
            await _userService.AddUserPreference(userId, categoryId);
            return Ok();
        }

        [HttpGet("preference/{userId}", Name = "GetUserPreferences")]
        public async Task<ActionResult<List<CategoryDto>>> GetUserPreferences(int userId)
        {
            return Ok(await _userService.GetUserPreferences(userId));
        }

        [HttpGet("preferences/places/{userId}")]
        public async Task<ActionResult<List<PlaceDto>>> GetPlacesBasedOnUserPreferences(int userId)
        {
            return Ok(await _userService.GetPlacesBasedOnUserPreferences(userId));
        }

        [HttpDelete("preferences/{userId}/{categoryId}", Name = "DeleteUserPreference")]
        public async Task<ActionResult> DeleteUserPreference(int userId, int categoryId)
        {
            await _userService.DeleteUserPreference(userId, categoryId);
            return Ok();
        }

        [HttpGet("favourite/{userId}", Name = "GetUserFavouritePlaces")]
        public async Task<ActionResult<List<PlaceDto>>> GetUserFavouritePlaces(int userId)
        {
            return Ok(await _userService.GetUserFavouritePlaces(userId));
        }

        [HttpGet("reviews/{userId}", Name = "GetUserReviews")]
        public async Task<ActionResult<List<ReviewDto>>> GetUserReviews(int userId)
        {
            return Ok(await _userService.GetUserReviews(userId));
        }

    }
}

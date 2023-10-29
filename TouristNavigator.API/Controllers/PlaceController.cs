using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Application.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.API.Controllers
{
    [Route("place")]
   // [Authorize]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("getbyid/{id}", Name = "GetPlaceById")]
        public async Task<ActionResult<Place>> getPlaceById(int id)
        {
            return Ok(await _placeService.GetByIdAsync(id));
        }

        [HttpGet("getall", Name = "GetAllPlaces")]
        public async Task<ActionResult<List<Place>>> GetAllPlaces()
        {
            return Ok(await _placeService.GetAllAsync());
        }


        [HttpPut("updateplace", Name = "UpdatePlace")]
        public async Task<ActionResult> UpdatePlace(Place place)
        {
            await _placeService.UpdateAsync(place);
            return Ok();
        }

        [HttpDelete("removeplace/{id}", Name = "RemovePlace")]
        public async Task<ActionResult> RemovePlace(int id)
        {
            await _placeService.RemoveAsync(id);
            return Ok();
        }

        [HttpPost("addplace", Name = "AddPlace")]
        public async Task<ActionResult> AddPlace(Place place)
        {
            await _placeService.CreateAsync(place);
            return Ok();
        }

        [HttpGet("review/{id}")]
        public async Task<ActionResult<List<ReviewDto>>> GetPlaceReviews(int id)
        {
            return Ok(await _placeService.GetPlaceReviews(id));
        }
    }
}

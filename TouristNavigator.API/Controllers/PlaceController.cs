using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Application.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.API.Controllers
{
    [Route("place")]
    [Authorize]
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

        [HttpDelete("removeplace", Name = "RemovePlace")]
        public async Task<ActionResult> RemovePlace(Place place)
        {
            await _placeService.RemoveAsync(place);
            return Ok();
        }

        [HttpPost("addplace", Name = "AddPlace")]
        public async Task<ActionResult> AddPlace(Place place)
        {
            await _placeService.CreateAsync(place);
            return Ok();
        }
    }
}

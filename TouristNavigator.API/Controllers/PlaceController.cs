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
        public async Task<ActionResult<List<PlaceDto>>> GetAllPlaces()
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
        public async Task<ActionResult<int>> AddPlace(AddPlaceDto place)
        {
            return Ok(await _placeService.CreateAsync(place));
        }

        [HttpPost("addcategory/{placeId}/{categoryId}", Name = "AddCategoryToPlace")]
        public async Task<ActionResult> AddCategoryToPlace(int placeId, int categoryId)
        {
            await _placeService.AddCategoryToPlace(placeId, categoryId);
            return Ok();
        }

        [HttpGet("review/{id}")]
        public async Task<ActionResult<List<ReviewDto>>> GetPlaceReviews(int id)
        {
            return Ok(await _placeService.GetPlaceReviews(id));
        }

        [HttpGet("categories/{placeId}", Name = "GetPlaceCategories")]
        public async Task<ActionResult<List<CategoryDto>>> GetPlaceCategories(int placeId)
        {
            return Ok(await _placeService.GetPlaceCategories(placeId));
        }

        [HttpPost("addphoto/{placeId}", Name = "AddPlacePhoto")]
        public async Task<ActionResult> AddPlacePhoto(int placeId, IFormFile photo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                byte[] iconData = memoryStream.ToArray();

                PlacePhotoDto dto = new PlacePhotoDto
                {
                    Photo = iconData
                };

                await _placeService.AddPhotoAsync(dto, placeId);
                return Ok();
            }
            return BadRequest("Plik ikony nie został przesłany.");
        }
    }
}

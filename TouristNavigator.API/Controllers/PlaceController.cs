using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
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
        public async Task<ActionResult> UpdatePlace(PlaceDto place)
        {
            PlaceDto newRequest = new PlaceDto();
            try
            {
                newRequest = place;             
                newRequest.Name = JsonSerializer.Deserialize<string>(place.Name);
                newRequest.Description = JsonSerializer.Deserialize<string>(place.Description);
                newRequest.Adress.City = JsonSerializer.Deserialize<string>(place.Adress.City);
                newRequest.Adress.Country = JsonSerializer.Deserialize<string>(place.Adress.Country);
                newRequest.Adress.Street = JsonSerializer.Deserialize<string>(place.Adress.Street);
                newRequest.Adress.PostalCode = JsonSerializer.Deserialize<string>(place.Adress.PostalCode);
                if(newRequest.Adress.LocalNumber != null) newRequest.Adress.LocalNumber = JsonSerializer.Deserialize<string>(place.Adress.LocalNumber);
                newRequest.Url = JsonSerializer.Deserialize<string>(place.Url);


            }
            catch (Exception ex)
            {
                newRequest = place;
            }

            await _placeService.UpdateAsync(newRequest);
            return Ok();
        }

        [HttpDelete("removeplace/{id}", Name = "RemovePlace")]
        public async Task<ActionResult> RemovePlace(int id)
        {
            await _placeService.RemoveAsync(id);
            return Ok();
        }

        [HttpPost("addplace", Name = "AddPlace")]
        public async Task<ActionResult<int>> AddPlace(AddPlaceRequest place)
        {

            AddPlaceRequest newRequest = new AddPlaceRequest();
            try
            {
                newRequest = place;
                newRequest.Name = JsonSerializer.Deserialize<string>(place.Name);
                newRequest.Description = JsonSerializer.Deserialize<string>(place.Description);
                newRequest.Adress.City = JsonSerializer.Deserialize<string>(place.Adress.City);
                newRequest.Adress.Country = JsonSerializer.Deserialize<string>(place.Adress.Country);
                newRequest.Adress.Street = JsonSerializer.Deserialize<string>(place.Adress.Street);
                newRequest.Adress.PostalCode = JsonSerializer.Deserialize<string>(place.Adress.PostalCode);
                newRequest.Adress.LocalNumber = JsonSerializer.Deserialize<string>(place.Adress.LocalNumber);           
                newRequest.Url = JsonSerializer.Deserialize<string>(place.Url);

               
            }
            catch (Exception ex)
            {
                newRequest = place;
            }

            byte[] byteArray = null;

            if (newRequest.Photo != null)
            {
                byteArray = Encoding.UTF8.GetBytes(newRequest.Photo);
            }
            


            AddPlaceDto placeDto = new AddPlaceDto
            {
                OwnerId = newRequest.OwnerId,
                Name = newRequest.Name,
                Description = newRequest.Description,
                Latitude = newRequest.Latitude,
                Longitude = newRequest.Longitude,
                Url = newRequest.Url,
                Adress = newRequest.Adress,
                Photo = byteArray,
            };

            return Ok(await _placeService.CreateAsync(placeDto));
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

        [HttpPost("setasfavourite/{placeId}/{userId}", Name = "SetPlaceAsFavourite")]
        public async Task<ActionResult> SetPlaceAsFavourite(int placeId, int userId)
        {
           await _placeService.SetPlaceAsFavourite(placeId, userId);
            return Ok();
        }

        [HttpGet("isfavourite/{placeId}/{userId}", Name = "CheckIfPlaceIsFavourite")]
        public async Task<ActionResult<bool>> CheckIfPlaceIsFavourite(int placeId, int userId)
        {
            return Ok(await _placeService.CheckIfPlaceIsFavourite(placeId, userId));
        }


        
    }
}

using Microsoft.AspNetCore.Mvc;
using System.IO;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Application.Models;
using TouristNavigator.Application.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.API.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall",Name = "GetAllCategories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }


        [HttpPost("addcategory", Name = "AddCategory")]
        public async Task<ActionResult> AddCategory( AddCategoryRequest category)
        {
            Category cat = new Category
            {
                Name = category.Name,
            };
            await _categoryService.AddAsync(cat);
            return Ok();
        }

        [HttpPost("addicon/{categoryId}", Name = "AddCategoryIcon")]
        public async Task<ActionResult> AddCategoryIcon(int categoryId, IFormFile icon)
        {
            using (var memoryStream = new MemoryStream())
            {
                await icon.CopyToAsync(memoryStream);
                byte[] iconData = memoryStream.ToArray();

                CategoryIconDto dto = new CategoryIconDto
                {
                    Icon = iconData
                };

                await _categoryService.AddIconAsync(dto, categoryId);
                return Ok();
            }
            return BadRequest("Plik ikony nie został przesłany.");
        }
    }
}

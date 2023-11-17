using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Application.Interfaces.Services;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryIconRepository _iconRepository;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryIconRepository iconRepository)
        {
            _categoryRepository = categoryRepository;
            _iconRepository = iconRepository;
        }

        public Task AddAsync(Category category)
        {
            return _categoryRepository.AddAsync(category);
        }

        public Task AddIconAsync(CategoryIconDto icon, int categoryId)
        {
            CategoryIcon i = new CategoryIcon
            {
                CategoryId = categoryId,
                Icon = icon.Icon
            };

            return _iconRepository.AddAsync(i);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllWithIcon();
            return categories.Select(c => c.toCategoryDto()).ToList();
        }
    }
}

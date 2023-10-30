using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync();
        public Task AddAsync(Category category);

        public Task AddIconAsync(CategoryIconDto icon, int categoryId);
    }
}

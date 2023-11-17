using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Repositories
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task AddCategoryToPlaceAsync(PlaceCategory category);
        Task<List<Category>> GetAllCategoriesAsync(int id);
        Task<List<Place>> GetAllWithPhoto();
        Task SetPlaceAsFavourite(FavouriteUserPlace favouritePlace);
        Task<bool> CheckIfPlaceIsFavourite(int placeId, int userId);
    }
}

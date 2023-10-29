using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IReviewService
    {
        public Task AddReviewAsync(ReviewDto review);
        public Task<List<ReviewDto>> GetAllReviewsAsync();
    }
}

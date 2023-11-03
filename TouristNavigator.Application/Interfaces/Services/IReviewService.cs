using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Dto;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Interfaces.Services
{
    public interface IReviewService
    {
        public Task<Review> AddReviewAsync(ReviewDto review);
        public Task<List<ReviewDto>> GetAllReviewsAsync();
    }
}

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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task AddReviewAsync(ReviewDto review)
        {
            Review newReview = new Review()
            {
                Id = review.Id,
                UserId = review.UserId,
                PlaceId = review.PlaceId,
                Comment = review.Comment,
                ReviewValue = review.ReviewValue,
                CreationTime = DateTime.Now,
            };
            return _reviewRepository.AddAsync(newReview);
           
        }

        public async Task<List<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Select(r => r.toReviewDto()).ToList();
        }
    }
}

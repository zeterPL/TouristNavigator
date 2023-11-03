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
        private readonly IPlaceService _placeService;

        public ReviewService(IReviewRepository reviewRepository, IPlaceService placeService)
        {
            _reviewRepository = reviewRepository;
            _placeService = placeService;
        }

        public async Task<Review> AddReviewAsync(ReviewDto review)
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

            var place = await _placeService.GetByIdAsync(review.PlaceId);
            var placeReviews = await _placeService.GetPlaceReviews(review.PlaceId);
            if(placeReviews.Count != 0)
            {
                var rates = placeReviews.Select(r => r.ReviewValue).ToList();
                var sum = rates.Sum() + newReview.ReviewValue;
                place.Rating = sum/(rates.Count() + 1);
            }
            else if (placeReviews.Count == 0)
            {
                place.Rating = newReview.ReviewValue;
            }
            await _placeService.UpdateAsync(place);
            return await _reviewRepository.AddAsync(newReview);
           
        }

        public async Task<List<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return reviews.Select(r => r.toReviewDto()).ToList();
        }
    }
}

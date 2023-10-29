using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ReviewValue { get; set; }
        public DateTime Date { get; set; }
       
        public int UserId { get; set; }      
        public int PlaceId { get; set; }
      
    }

    public static class ReviewExtensions
    {
        public static ReviewDto toReviewDto(this Review review) 
        {
            return new ReviewDto
            {
                Id = review.Id,
                Comment = review.Comment,
                ReviewValue = review.ReviewValue,
                UserId = review.UserId,
                PlaceId = review.PlaceId,
                Date = review.CreationTime
            };
        }
    }
}

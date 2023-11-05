using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;
using TouristNavigator.Domain.ValueObjects;

namespace TouristNavigator.Application.Dto
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Url { get; set; }
        public Adress Adress { get; set; }
        public double Rating { get; set; }
        public byte[] Photo { get; set; }
    }

    public static class PlaceExtensions
    {
        public static PlaceDto toPlaceDto(this Place place)
        {
            var dto = new PlaceDto
            {
                Id = place.Id,
                OwnerId = place.OwnerId,    
                Name = place.Name,
                Description = place.Description,
                Latitude = place.Latitude,
                Longitude = place.Longitude,
                Url = place.Url,
                Adress = place.Adress,
                Rating = place.Rating,
                
            };
            if (place.PlacePhoto != null)
            {
                dto.Photo = place.PlacePhoto.Photo;
            }
            return dto;
        }
    }
}

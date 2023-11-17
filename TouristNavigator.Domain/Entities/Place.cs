using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.ValueObjects;

namespace TouristNavigator.Domain.Entities
{
    public class Place
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

        public virtual PlacePhoto PlacePhoto { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<PlaceCategory> Categories { get; set; }
        public virtual ICollection<FavouriteUserPlace> FavouriteUsers { get; set; }
    }
}

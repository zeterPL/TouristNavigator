using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Place> OwnedPlaces { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
        public virtual ICollection<FavouriteUserPlace> FavouritePlaces { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual CategoryIcon Icon { get; set; }

        public virtual ICollection<PlaceCategory> RelatedPlaces { get; set; }
        public virtual ICollection<UserPreferences> RelatedUsers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class PlaceCategory
    {
        public virtual Place Place { get; set; }
        public int PlaceId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class PlacePhoto
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public byte[] Photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ReviewValue { get; set; }
        public DateTime CreationTime { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}

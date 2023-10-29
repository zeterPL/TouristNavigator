using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.Entities
{
    public class UserPreferences
    {
        public virtual ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; } 
    }
}

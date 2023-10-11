using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Application.Security.Models
{
    public class RegistrationRequest
    {
        public string UserName { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public string Password { get; set; }
    }
}

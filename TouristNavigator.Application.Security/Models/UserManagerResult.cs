using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Application.Security.Models
{
    public class UserManagerResult
    {
        public bool Succeeded { get; private set; }
        public List<string> Errors { get; private set; }

        public static UserManagerResult Success = new UserManagerResult() { Succeeded = true };

        public static UserManagerResult Failed(List<string> errors)
        {
            return new UserManagerResult()
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Application.Security.Models
{
    public class SignInResult
    {
        public bool Succeeded { get; protected set; }
        public bool IsLockedOut { get; protected set; }
        public bool IsNotAllowed { get; protected set; }

        public static SignInResult Success = new SignInResult()
        {
            Succeeded = true,
            IsLockedOut = false,
            IsNotAllowed = false
        };

        public static SignInResult Fail = new SignInResult()
        {
            Succeeded = false,
            IsLockedOut = false,
            IsNotAllowed = false
        };
    }
}

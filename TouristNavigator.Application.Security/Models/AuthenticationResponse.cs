﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Application.Security.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get;set; }
        public string Email { get;set; }
        public string Token { get; set; }
    }
}

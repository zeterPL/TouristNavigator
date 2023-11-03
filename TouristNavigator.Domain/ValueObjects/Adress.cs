﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigator.Domain.ValueObjects
{
    public class Adress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? LocalNumber { get; set; }
        public string PostalCode { get; set; }
    }
}

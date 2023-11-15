﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.ValueObjects;

namespace TouristNavigator.Application.Dto
{
    public class AddPlaceDto
    {       
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Url { get; set; }
        public Adress Adress { get; set; }      
        public byte[]? Photo { get; set; }
    }
}

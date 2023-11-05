﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure.Repositories
{
    public class PlacePhotoRepository : BaseRepository<PlacePhoto>, IPlacePhotoRepository
    {
        public PlacePhotoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

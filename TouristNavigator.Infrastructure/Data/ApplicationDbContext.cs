using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Place> Places { get; set; }
    }
}

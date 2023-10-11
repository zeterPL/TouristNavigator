using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Application.Interfaces.Repositories;
using TouristNavigator.Domain.Entities;
using TouristNavigator.Infrastructure.Data;

namespace TouristNavigator.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}

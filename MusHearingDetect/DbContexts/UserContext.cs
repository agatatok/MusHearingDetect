using Microsoft.EntityFrameworkCore;
using MusHearingDetect.Models.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MusHearingDetect.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}

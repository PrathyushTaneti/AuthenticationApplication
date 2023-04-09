using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAuthApi.Models;

namespace BackEndAuthApi.Data
{
    public class BackEndAuthApiContext : DbContext
    {
        public BackEndAuthApiContext (DbContextOptions<BackEndAuthApiContext> options)
            : base(options)
        {
        }

        public DbSet<BackEndAuthApi.Models.User> User { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using MKFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories
{
    public class MKFYApplicationDbContext: DbContext

    {
        public MKFYApplicationDbContext(DbContextOptions<MKFYApplicationDbContext> options)
          : base(options)
        {
            // This is where you can use the Fluent API to have finer control over the database setup.
            // Anything you can do with data annotations on the entity models can also be done with the
            // fluent API.
        }

        public DbSet<MKFYList> MKFYListItems => Set<MKFYList>();
        public DbSet<User> Users=> Set<User>();
        public DbSet<UserLog> UserLogs=> Set<UserLog>();

    }
}

using Microsoft.EntityFrameworkCore;
using MKFY.Models.Entities;
using MKFY.Repositories.Repositories;
using MKFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositories
{
    public class UserLogRepository : IUserLogRepository
    {
        private readonly MKFYApplicationDbContext _context;
        public UserLogRepository(MKFYApplicationDbContext context)

        {
            _context = context;
        }
        //create a new item
        public void Create(UserLog entity)
        {
            //add the created date
            entity.LogCreated = DateTime.UtcNow;
            //perform the add in memory
            _context.Add(entity);

        }
        // Get a single existing userlogs by Id
       
        // Get all of the items
        public async Task<List<UserLog>> SearchDeals(string UserId)
        {
            // Get all the entities
            var results = await _context.UserLogs.Where(d => d.UserName == UserId)
                .OrderByDescending(d => d.LogCreated)
                .Take(3).ToListAsync(); 

            // Return the retrieved entities
            return results;
        }

        // Update an existing userlog
        public void Update(UserLog entity)
        {
            // Update the entity
            _context.Update(entity);
        }
       
        
        // Delete a userlog
        public void Delete(UserLog entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }

        
    }
}

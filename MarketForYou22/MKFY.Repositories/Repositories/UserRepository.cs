using Microsoft.EntityFrameworkCore;
using MKFY.Models.Entities;
using MKFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MKFYApplicationDbContext _context;

        public UserRepository(MKFYApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new user
        public void Create(User entity)
        {
            // Perform the add in memory
            _context.Add(entity);
        }

        // Get a single user by Id
        // Note: Will return null if user doesn't exist
        public async Task<User> GetById(string id)
        {
            // Get the entity
            var result = await _context.Users.FirstAsync(i => i.Id == id);

            // Return the retrieved entity
            return result;
        }

        // Update an existing user
        public void Update(User entity)
        {
            // Update the entity
            _context.Update(entity);
        }
    }
}

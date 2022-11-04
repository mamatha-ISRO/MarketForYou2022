using MKFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        
            void Create(User entity);       // Create a new user
            Task<User> GetById(string id);  // Get a single user by Id
            void Update(User entity);       // Update an existing user
        }
    }



using MKFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositories.Interfaces
{
    public interface IUserLogRepository
    {
        void Create(UserLog entity);       // Create a new userlog
       
        Task<List<UserLog>> SearchDeals(string id);  // Get a single user by Id and last three searches
        void Update(UserLog entity);       // Update an existing user
        void Delete(UserLog entity); //Delet a user log

    }
}

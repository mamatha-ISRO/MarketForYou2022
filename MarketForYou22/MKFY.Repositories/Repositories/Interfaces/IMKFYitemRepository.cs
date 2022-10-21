using MKFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositoies.Interfaces
{
    public interface IMKFYitemRepository
    {
        void Create(MKFYList entity);         // Create a new item
        Task<MKFYList> GetById(Guid id);      // Get a single existing Item by Id
        Task<List<MKFYList>> GetAll();        // Get all of the Item
        void Update(MKFYList entity);         // Update an existing Item
        void Delete(MKFYList entity);         // Delete a Item
    }
}

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
        Task<List<MKFYList>> Search(String? search, String? category);     // search  a single existing Item 
        Task<List<MKFYList>> GetCategory(String category);
        void Create(MKFYList entity);         // Create a new item
        Task<MKFYList> GetById(Guid id);      // Get a single existing Item by Id
        Task<List<MKFYList>> GetAll();        // Get all of the Item
        void Update(MKFYList entity);         // Update an existing Item
        void Purchase(MKFYList entity);     // Update an existing Item buyerId when user purchase
        void Delete(MKFYList entity);         // Delete a Item
        Task<IQueryable<MKFYList>> ToListAsync();
        Task<List<MKFYList>>UserDeals(string userName);
    }
}

using MKFY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Services.Services.Interfaces
{
    public interface IMKFYListServise
    {
        Task<List<MKFYlistVM>>Search(String? name, String? category); // Search item by name and category
        Task<List<MKFYlistVM>> UserDeals(string Id);
        Task<List<MKFYlistVM>> GetCategory(String category);
        Task<MKFYlistVM> Create(MKFYListAddVM src, String userId);       // Create a new item
        Task<MKFYlistVM> GetById(Guid id);                // Get a single existing item by Id
        Task<List<MKFYlistVM>> GetAll();                  // Get all of the items
        Task<MKFYlistVM> Update(MKFYListUpdateVM src);    // Update an existing item
        Task<MKFYlistVM> Purchase(MKFYListUpdateVM src, string userId);    // Update an purchase item  existing item
        Task Delete(Guid id);                            // Delete a item
        
    }
}

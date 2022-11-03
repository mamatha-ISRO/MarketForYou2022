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

        Task<MKFYlistVM> Create(MKFYListAddVM src);       // Create a new item
        Task<MKFYlistVM> GetById(Guid id);                // Get a single existing item by Id
        Task<List<MKFYlistVM>> GetAll();                  // Get all of the items
        Task<MKFYlistVM> Update(MKFYListUpdateVM src);    // Update an existing item
        Task Delete(Guid id);                            // Delete a item
    }
}

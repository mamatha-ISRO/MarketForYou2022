using Microsoft.EntityFrameworkCore;
using MKFY.Models.Entities;
using MKFY.Repositories.Repositoies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories.Repositoies
{
    public class MKFYItemRepository: IMKFYitemRepository
    { 
        private readonly MKFYApplicationDbContext _context;
        public MKFYItemRepository(MKFYApplicationDbContext context)

        {
            _context= context;
        }
        //create a new item
        public void Create(MKFYList entity)
        {
            //add the created date
            entity.Created = DateTime.UtcNow;
            //perform the add in memory
            _context.Add(entity);

        }
        // Get a single existing item by Id
        public async Task<MKFYList> GetById(Guid id)
        {
            // Get the entity
            var result = await _context.MKFYListItems.FirstAsync(item => item.Id == id);

            // Return the retrieved entity
            return result;
        }

        // Get all of the items
        public async Task<List<MKFYList>> GetAll()
        {
            // Get all the entities
            var results = await _context.MKFYListItems.ToListAsync();

            // Return the retrieved entities
            return results;
        }

        // Update an existing item
        public void Update(MKFYList entity)
        {
            // Update the entity
            _context.Update(entity);
        }

        // Delete a item
        public void Delete(MKFYList entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }
    }
}

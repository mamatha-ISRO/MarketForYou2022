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
        //select the last three searches of user for display items as deals 
        public async Task<List<MKFYList>>SelectlastsearchItems(List<UserLog> listofItemdeals)
        {
            var finaldealsLst = new List<MKFYList>();
            // Get all the entities
            foreach (var search in listofItemdeals) {
                var results = await _context.MKFYListItems.Where(e => e.ItemName.Contains(search.SearchString))
                    .Distinct()
                    .OrderBy(e => e.ItemPrice).ToListAsync();

                 finaldealsLst.AddRange(results);
            }
            // Return the retrieved entities
            return finaldealsLst;
        }
        // Get all of the items
        public async Task<List<MKFYList>> GetAll()
        {
            // Get all the entities
            var results = await _context.MKFYListItems.ToListAsync();

            // Return the retrieved entities
            return results;
        }
        public async Task<List<MKFYList>> UserDeals(string Id)
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
        // Update an existing item when user purchase
        public void Purchase(MKFYList entity)
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


       //Impliment search in the market items 
        public async Task<List<MKFYList>> Search(string? search, string? category)
        {
            var query = _context.MKFYListItems.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.ItemName.Contains(search));
            }

            if (category!= null)
            {
                query = query.Where(e => e.ItemCategory == category);
            }

            return await query.ToListAsync();
        }
        public async Task<List<MKFYList>> GetCategory( string category)
        {
            IQueryable<MKFYList> query = (IQueryable<MKFYList>)await _context.MKFYListItems.ToListAsync(); 

           if (category != null)
            {
                query = query.Where(e => e.ItemCategory == category);
            }

            return await query.ToListAsync();
        }

        
            Task<IQueryable<MKFYList>> IMKFYitemRepository.ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
    }


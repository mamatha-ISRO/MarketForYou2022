using Microsoft.EntityFrameworkCore;
using MKFY.Models.Entities;
using MKFY.Models.ViewModels;
using MKFY.Repositories;
using MKFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Services.Services
{
    public class MKFYListServise: IMKFYListServise
   
        {
            private readonly IUnitOfWork _uow;

            public MKFYListServise(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<MKFYlistVM> Create(MKFYListAddVM src, string userId)
            {
                // Create the new item entity
                var newEntity = new MKFYList(src,userId);

                // Have the repository create the new item
                _uow.MKFYListItems.Create(newEntity);
                await _uow.SaveAsync();

                // Create the item VM we want to return to the client
                var model = new MKFYlistVM(newEntity);

                // Return a item
                return model;
            }
        //Impliment search in the market items 
        public async Task<List<MKFYlistVM>>Search(String? search, String? category)
        {
            var results = await _uow.MKFYListItems.Search(search, category);
            
            //Log the user search
            // Create the new Log for the user entity
            var newEntity = new UserLog();

            // Have the repository create the new game
            _uow.UserLogs.Create(newEntity);
            await _uow.SaveAsync();

            // Create the UserLogVM we want to return to the client
          

            var views = results.Select(listItem => new MKFYlistVM(listItem)).ToList();

            return views;
        }

        public async Task<List<MKFYlistVM>>UserDeals(string UserId)
        {

            //select the search logs with user id from logtable, 
            var Last3Searches = await _uow.UserLogs.SearchDeals(UserId);

            // select lits of items with search string 
            var listofItemdeals = await _uow.MKFYListItems.SelectlastsearchItems(Last3Searches);

            var listofItemdeals = await _uow.MKFYListItems.SelectlastsearchItems(e => new e.ItemName.contains((Last3Searches(1).SearchString) && OR && (Last3Searches(2).SearchString) && OR && (Last3Searches(3).SearchString)))
                     .Distinct()
                     .OrderBy(e => e.ItemPrice).ToListAsync();
            //in the GetlogsbyUserName need to find 3 logs list , get all the 
            //take the last three searchstrings from table , selct them from market items table and acsend with price and send to list


        }
        public async Task<List<MKFYlistVM>>GetCategory(string category)
        {
            IQueryable<MKFYList> query = (IQueryable<MKFYList>)await _uow.MKFYListItems.ToListAsync();

           
            if (category != null)
            {
                query = query.Where(e => e.ItemCategory == category);
            }

            
            return (List<MKFYlistVM>)query;
        }

        public async Task<List<MKFYlistVM>> GetAll()
            {
                // Get the item entities from the repository
                var results = await _uow.MKFYListItems.GetAll();

                // Build the itemVM view models to return to the client
                var models = results.Select(item => new MKFYlistVM(item)).ToList();

                // Return the item
                return models;
            }

            public async Task<MKFYlistVM> GetById(Guid id)
            {
                // Get the requested  market item entity from the repository
                var result = await _uow.MKFYListItems.GetById(id);

                // Create the item VM we want to return to the client
                var model = new MKFYlistVM(result);

                // Return a 200 response with the market item
                return model;
            }

            public async Task<MKFYlistVM> Update(MKFYListUpdateVM src)
            {
                // Get the existing entity
                var entity = await _uow.MKFYListItems.GetById(src.Id);

                // Perform the update
                entity.ItemName = src.ItemName;
                entity.ItemDescription = src.ItemDescription;
                entity.ItemPrice = src.ItemPrice;
                entity.PickAddress = src.PickAddress;
                entity.ItemCity = src.ItemCity;

                // Have the repository update the item
                _uow.MKFYListItems.Update(entity);
                await _uow.SaveAsync();

                // Create the item VM we want to return to the client
                var model = new MKFYlistVM(entity);

                // Return a 200 response with the item VM
                return model;
            }

        //when user purchases update market list item 
        public async Task<MKFYlistVM> Purchase(MKFYListUpdateVM src, string userId)
        {
            // Get the existing entity
            var entity = await _uow.MKFYListItems.GetById(src.Id );

            // Perform the update
           
            entity.BuyerId = userId;          

            // Have the repository update the item
            _uow.MKFYListItems.Update(entity);
            await _uow.SaveAsync();

            // Create the item VM we want to return to the client
            var model = new MKFYlistVM(entity);

            // Return a 200 response with the item VM
            return model;
        }
        public async Task Delete(Guid id)
            {
                // Get the existing entity
                var entity = await _uow.MKFYListItems.GetById(id);

                // Tell the repository to delete the requested item entity
                _uow.MKFYListItems.Delete(entity);
                await _uow.SaveAsync();
            }

       
    }
}

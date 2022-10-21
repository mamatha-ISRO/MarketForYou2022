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

            public async Task<MKFYlistVM> Create(MKFYListAddVM src)
            {
                // Create the new item entity
                var newEntity = new MKFYList(src);

                // Have the repository create the new game
                _uow.MKFYListItems.Create(newEntity);
                await _uow.SaveAsync();

                // Create the item VM we want to return to the client
                var model = new MKFYlistVM(newEntity);

                // Return a item
                return model;
            }

            public async Task<List<MKFYlistVM>> GetAll()
            {
                // Get the item entities from the repository
                var results = await _uow.MKFYListItems.GetAll();

                // Build the itemVM view models to return to the client
                var models = results.Select(item => new MKFYlistVM(item)).ToList();

                // Return the GameVMs
                return models;
            }

            public async Task<MKFYlistVM> GetById(Guid id)
            {
                // Get the requested Game entity from the repository
                var result = await _uow.MKFYListItems.GetById(id);

                // Create the GameVM we want to return to the client
                var model = new MKFYlistVM(result);

                // Return a 200 response with the GameVM
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

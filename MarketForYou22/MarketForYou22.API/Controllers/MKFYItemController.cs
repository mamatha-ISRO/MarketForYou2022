using MarketForYou22.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKFY.Models.ViewModels;
using MKFY.Repositories.Repositoies;
using MKFY.Services.Services.Interfaces;

namespace MarketForYou22.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MKFYItemController : ControllerBase
    {
        private readonly IMKFYListServise _MKFYService;

        public MKFYItemController(IMKFYListServise MKFYService)
        {
            _MKFYService = MKFYService;
        }

        // Create a new item
        [HttpPost]
        public async Task<ActionResult<MKFYlistVM>> Create([FromBody] MKFYListAddVM data)
        {
            try
            {
                var userId = User.GetId();
                if (userId == null)
                    return BadRequest("Invalid User");
                // Have the service create the new item
                var result = await _MKFYService.Create(data, userId);


                // Return a 200 response with the item vm
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //impliment search menthod
        [HttpGet]
        public async Task<ActionResult<List<MKFYlistVM>>> Search([FromQuery] string? search, [FromQuery] String? category)
        {
            try
            {
                var result = await _MKFYService.Search(search, category);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }


        }

        // Get a specific item by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<MKFYlistVM>> Get([FromRoute] Guid id)
        {
            try
            {
                // Get the requested item entity from the service
                var result = await _MKFYService.GetById(id);

                // Return a 200 response with the item VM
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the requested  market item" });
            }
        }
        // Get all items list
        [HttpGet]
        // [Authorize(Roles= "MKADMIN")]
        public async Task<ActionResult<List<MKFYlistVM>>> GetAll()
        {
            try
            {
                // Get the items entities from the service
                var results = await _MKFYService.GetAll();

                // Return a 200 response with the GameVMs
                return Ok(results);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the market item" });
            }
        }

        [HttpGet("{ItemCategory}")]
        public async Task<ActionResult<List<MKFYlistVM>>> GetCategory(String category)
        {
            try
            {
                // Get the requested category items from the service
                var result = await _MKFYService.GetCategory(category);

                // Return a 200 response with the item VM
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the requested  market item" });
            }
        }

        // Update a item
        [HttpPut]
        public async Task<ActionResult<MKFYlistVM>> Update([FromBody] MKFYListUpdateVM data)
        {
            try
            {
                // Update item entity from the service
                var result = await _MKFYService.Update(data);

                // Return a 200 response with the item vm
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("userDeals/user")]
        public async Task<ActionResult<List<MKFYlistVM>>> UserDeals()
        {
            try
            {
                var userId = User.GetId();
                var result = await _MKFYService.UserDeals(userId);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }

        }

        private async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                // Tell the repository to delete the requested item entity
                await _MKFYService.Delete(id);

                // Return a 200 response
                return Ok();
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch
            {
                return BadRequest(new { message = "Unable to delete the requested  market item" });
            }
        }

        private async Task<ActionResult<MKFYlistVM>> Purchase([FromBody] MKFYListUpdateVM data, string id)
        {
            try
            {
                // Update item entity from the service

                //the data needs to be updated with buyer id and the isold 
                //user UserOrder details of the buyer id = curret user id , isold=true
                var BuyerId = id;
                var result = await _MKFYService.Purchase(data, BuyerId);

                // Return a 200 response with the item vm
                return Ok(result);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

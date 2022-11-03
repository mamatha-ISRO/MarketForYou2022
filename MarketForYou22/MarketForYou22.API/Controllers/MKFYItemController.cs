using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKFY.Models.ViewModels;
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
        public async Task<ActionResult<MKFYlistVM>>Create([FromBody] MKFYListAddVM data)
        {
            try
            {
                // Have the service create the new item
                var result = await _MKFYService.Create(data);

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
                return BadRequest(new { message = "Unable to retrieve the games" });
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

        // Delete a item
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
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
                return BadRequest(new { message = "Unable to delete the requested game" });
            }
        }

    }
}

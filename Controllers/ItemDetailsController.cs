using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseControl.Models;

namespace WarehouseControl.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly ItemDetailContext _context;

        public ItemDetailsController(ItemDetailContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetails
        [HttpGet]
        public IEnumerable<ItemDetail> GetItemDetails()
        {
            return _context.ItemDetails;
        }

        // GET: api/ItemDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetail = await _context.ItemDetails.FindAsync(id);

            if (itemDetail == null)
            {
                return NotFound();
            }

            return Ok(itemDetail);
        }

        // PUT: api/ItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetail([FromRoute] int id, [FromBody] ItemDetail itemDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemDetail.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemDetails
        [HttpPost]
        public async Task<IActionResult> PostItemDetail([FromBody] ItemDetail itemDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemDetails.Add(itemDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemDetail", new { id = itemDetail.ItemId }, itemDetail);
        }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetail = await _context.ItemDetails.FindAsync(id);
            if (itemDetail == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetail);
            await _context.SaveChangesAsync();

            return Ok(itemDetail);
        }

        private bool ItemDetailExists(int id)
        {
            return _context.ItemDetails.Any(e => e.ItemId == id);
        }
    }
}
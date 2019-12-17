using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WarehouseControl.Models;

namespace WarehouseControl.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WarehouseControl.Models.ItemDetailContext _context;

        public DetailsModel(WarehouseControl.Models.ItemDetailContext context)
        {
            _context = context;
        }

        public ItemDetail ItemDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemDetail = await _context.ItemDetails.SingleOrDefaultAsync(m => m.ItemId == id);

            if (ItemDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

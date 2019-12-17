using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseControl.Models;

namespace WarehouseControl.Pages
{
    public class EditModel : PageModel
    {
        private readonly WarehouseControl.Models.ItemDetailContext _context;

        public EditModel(WarehouseControl.Models.ItemDetailContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ItemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}

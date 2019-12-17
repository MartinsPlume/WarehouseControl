using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseControl.Models;

namespace WarehouseControl.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WarehouseControl.Models.ItemDetailContext _context;

        public CreateModel(WarehouseControl.Models.ItemDetailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemDetail ItemDetail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemDetails.Add(ItemDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
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
    public class IndexModel : PageModel
    {
        private readonly WarehouseControl.Models.ItemDetailContext _context;

        public IndexModel(WarehouseControl.Models.ItemDetailContext context)
        {
            _context = context;
        }

        public IList<ItemDetail> ItemDetails { get; set; }

        public async Task OnGetAsync()
        {
            ItemDetails = await _context.ItemDetails.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseControl.Models
{
    public class ItemDetailContext:DbContext
    {
        public ItemDetailContext(DbContextOptions<ItemDetailContext> options):base(options)
        {

        }

        public DbSet<ItemDetail> ItemDetails { get; set; }
    }
}

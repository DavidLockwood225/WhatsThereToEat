using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhereDaGrubAt.Models;

namespace WhereDaGrubAt.Data
{
    public class WhereDaGrubAtContext : DbContext
    {
        public WhereDaGrubAtContext (DbContextOptions<WhereDaGrubAtContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingList>().HasKey(p => new { p.Id, p.ItemName });
        }

        public DbSet<WhereDaGrubAt.Models.Item> Item { get; set; }

        public DbSet<WhereDaGrubAt.Models.Recipe> Recipe { get; set; }

        public DbSet<WhereDaGrubAt.Models.ShoppingList> ShoppingList { get; set; }
    }
}

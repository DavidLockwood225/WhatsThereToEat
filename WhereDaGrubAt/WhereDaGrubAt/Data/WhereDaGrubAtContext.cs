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

        public DbSet<WhereDaGrubAt.Models.Item> Item { get; set; }

        public DbSet<WhereDaGrubAt.Models.Recipe> Recipe { get; set; }
    }
}

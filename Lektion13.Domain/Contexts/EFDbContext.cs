using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion13.Domain.Entities;
using System.Data.Entity;

namespace Lektion13.Domain.Contexts
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
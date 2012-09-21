using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamEat.Domain.Entities;
using System.Data.Entity;

namespace TeamEat.Domain.Contexts
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
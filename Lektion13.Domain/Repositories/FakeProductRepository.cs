using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamEat.Domain.Entities;

namespace TeamEat.Domain.Repositories
{
    public class FakeProductRepository : FakeRepository<Product>, IProductRepository
    {
        public FakeProductRepository(params Product[] products)
        {
            context = products.ToList();
        }

        public IQueryable<Product> FindProductsByCategoryID(int id)
        {
            return new List<Product>().AsQueryable();
        }
    }
}
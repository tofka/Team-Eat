using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamEat.Domain.Entities.Abstract;

namespace TeamEat.Domain.Entities
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
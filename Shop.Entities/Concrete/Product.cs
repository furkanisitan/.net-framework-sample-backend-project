﻿using Shop.Core.Entities;

namespace Shop.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
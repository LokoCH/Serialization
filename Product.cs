using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class Product
    {
        public decimal _price;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product() { }
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}

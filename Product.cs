using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    public class Product
    {
        public decimal _price;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public Product() { }
        public Product(Guid id, string name, decimal price, int count = 1)
        {
            Id = id;
            Name = name;
            Price = price;
            Count = count;  
        }
        public Product(Product product, int count)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Count = count;
        }

        public string PrintProduct()
        {
            return $"{Name}\t{Price}";
        }
    }
}

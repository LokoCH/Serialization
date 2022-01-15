using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }
        public Customer(Guid id, string name, string phone, string email, List<Product> products)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Products = new List<Product>(products);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; }

    }
}

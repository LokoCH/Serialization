using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Serialization
{
    public class OrderReader : BaseModelReader, IEnumerable<Order>
    {
        private readonly IEnumerable<Customer> _customers;
        private readonly IEnumerable<Product> _products;

        public OrderReader(string filename, IEnumerable<Customer> customers, IEnumerable<Product> products) : base(filename)
        {
            _customers = customers;
            _products = products;
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return new OrderEnumerator(this);
        }

        public Order ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            Order tmp = JsonSerializer.Deserialize<Order>(s);

            foreach (var customer in _customers)
            {
                foreach (var product in _products)
                {
                    if (tmp.CustomerId == customer.Id && tmp.ProductId == product.Id)
                    {
                        customer.Products.Add(new Product(product, tmp.Count));
                    }
                }
            }
            return tmp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

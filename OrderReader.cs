﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleApp12
{
    public class OrderReader : BaseModelReader
    {
        private readonly IEnumerable<Customer> _customers;
        private readonly IEnumerable<Product> _products;

        public OrderReader(string filename, IEnumerable<Customer> customers, IEnumerable<Product> products) : base(filename)
        {
            _customers = customers;
            _products = products;
        }
        public IEnumerable<Order> ReadAll()
        {
            if (IsOpened) Close();
            Order c;
            while ((c = ReadNext()) != null)
            {
                foreach (var customer in _customers)
                {
                    foreach (var product in _products)
                    {
                        if (c.CustomerId == customer.Id && c.ProductId == product.Id)
                        {
                            customer.Products.Add(product);
                        }
                    }
                }
                yield return c;
            }
        }

        public Order ReadNext()
        {
            if (!IsOpened) Open();
            var s = ReadLine();
            if (s == null)
                return null;
            return JsonSerializer.Deserialize<Order>(s);
        }

    }
}
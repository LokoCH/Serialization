﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class Order
    {
        public Order()
        {

        }
        public Order(Guid productId, Guid customerId)
        {
            ProductId = productId;
            CustomerId = customerId;
        }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
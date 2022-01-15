using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    public class Order
    {
        public Order() { }
        public Order(Guid productId, Guid customerId, int count)
        {
            ProductId = productId;
            CustomerId = customerId;
            Count = count;
        }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Count { get; set; }
    }
}

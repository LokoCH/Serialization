using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    public static class OrdersInfo
    {
        public static decimal GetSumm(Customer customer)
        {
            return customer.Products.Sum(p => p.Price*p.Count);
        }
        public static decimal Summa(IEnumerable<Customer>customers)
        {
            return customers.Sum(c=>c.Products.Sum(p=>p.Price*p.Count));
        }
        public static decimal Summa(IEnumerable<Customer>customers, string product)
        {
            return customers.Sum(c=>c.Products.Where(p=>p.Name == product).Sum(p=>p.Price*p.Count));
        }
    }
}

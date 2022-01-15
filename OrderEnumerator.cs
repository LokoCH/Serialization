using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    internal class OrderEnumerator : IEnumerator<Order>
    {
        private readonly Order[] _orders;
        private int _index;

        public OrderEnumerator(IEnumerable<Order>orders)
        {
            _orders = orders.ToArray();
        }
        public Order Current => _orders[_index];

        public bool MoveNext()
        {
            _index++;
            return _orders[_index] != null;
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose() { }

        public void Reset() {}
    }
}

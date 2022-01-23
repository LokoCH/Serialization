using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    internal class OrderEnumerator : IEnumerator<Order>
    {
        private readonly OrderReader _reader;
        private Order _order;

        public OrderEnumerator(OrderReader or)
        {
            _reader = or;
        }
        public Order Current => _order;

        public bool MoveNext()
        {
            return (_order = _reader.ReadNext()) != null;
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose() { }

        public void Reset() {}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Serialization
{
    class CustomerEnumerator : IEnumerator<Customer>
    {
        private readonly Customer[] _customers;
        private int _index;

        public CustomerEnumerator(IEnumerable<Customer> customers)
        {
            _customers = customers.ToArray();
        }
        public Customer Current =>_customers[_index];

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            _index++;
            return _customers[_index] != null;
        }

        public void Dispose() { }

        public void Reset(){}
    }
}

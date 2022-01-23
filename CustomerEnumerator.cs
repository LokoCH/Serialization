using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Serialization
{
    class CustomerEnumerator : IEnumerator<Customer>
    {
        private readonly CustomersReader _reader;
        private Customer _customer;

        public CustomerEnumerator(CustomersReader cr)
        {
            _reader = cr;
        }
        public Customer Current => _customer;

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose() { }

        public bool MoveNext()
        {
           return (_customer = _reader.ReadNext()) != null;
        }

        public void Reset() { }
    }
}

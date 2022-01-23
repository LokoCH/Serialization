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

//        public CustomerEnumerator(IEnumerable<Customer> customers)
//        {
//            _customers = customers.ToArray();
//        }
//        public Customer Current
//        {
//            get
//            {
//                return _customers[_index];
//            }
//        }

//        object IEnumerator.Current
//        {
//            get;
//        }
//        public void Dispose()
//        {
//        }

        public void Dispose() { }

        public void Reset(){}
    }
}

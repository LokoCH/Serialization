//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace ConsoleApp12
//{
//    class CustomerEnumerator : IEnumerator<Customer>
//    {
//        private readonly Customer[] _customers;
//        private int _index;

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

//        public bool MoveNext()
//        {
//            _index++;
//        }

//        public void Reset()
//        {
//        }
//    }
//}

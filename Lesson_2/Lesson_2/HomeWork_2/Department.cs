using System;
using System.Collections;
using System.Text;

namespace HomeWork_2
{
    class Department : IEnumerable
    {
        public int Length { get; private set; }
        private Employee[] arr;

        public Department(int count)
        {
            Length = count;
            arr = new Employee[Length];
        }
        public Employee this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }



        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    }
}

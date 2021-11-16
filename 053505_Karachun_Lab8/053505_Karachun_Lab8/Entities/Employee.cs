using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab8.Interfaces;

namespace _053505_Karachun_Lab8.Entities
{
    class Employee
    {
        public int age;
        public bool isAlive;
        public string Name;
     
    }
    class EmployeeComparer<T> : IComparer<T>
        where T: Employee
    {
        public int Compare(T x, T y)
        {
            int compRes = String.Compare(x.Name, y.Name);
            if (compRes <0 )
            {
                return 1;
            }
            if (compRes >0)
            {
                return -1;
            }
            else { return 0; }
        }
    }
}

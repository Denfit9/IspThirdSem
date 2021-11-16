using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab8.Interfaces;

namespace _053505_Karachun_Lab8.Entities
{
    class Employee: FileService, IFileService
    {
        public int age;
        public bool isAlive;
        public string Name;
    }
}

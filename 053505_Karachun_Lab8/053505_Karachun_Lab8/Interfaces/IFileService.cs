using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab8.Entities;

namespace _053505_Karachun_Lab8.Interfaces
{
    interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}

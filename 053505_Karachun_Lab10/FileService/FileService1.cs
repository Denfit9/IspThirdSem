using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab10.Interfaces;
using _053505_Karachun_Lab10.Entities;

namespace FileService
{
    public class FileService1<T> : IFileService<T>
        where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            List<Employee> employees = new();
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(employees.GetType());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                employees.AddRange((List<Employee>)formatter.ReadObject(fs));
            }
             return (IEnumerable<T>)employees;
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(data.GetType());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, data);
            }
        }
    }
}

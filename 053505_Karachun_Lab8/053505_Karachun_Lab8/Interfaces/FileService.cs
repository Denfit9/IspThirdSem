using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab8.Entities;

namespace _053505_Karachun_Lab8.Interfaces
{
    public  class FileService: IFileService
    {
        internal readonly object SaveData;

        IEnumerable<Employee> IFileService.ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int age = reader.ReadInt32();
                    bool isAlive = reader.ReadBoolean();
                    string Name = reader.ReadString();
                    yield return new Employee();
                }
            }
        }

        void IFileService.SaveData(IEnumerable<Employee> data, string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (Employee emp in data)
                {
                    writer.Write(emp.age);
                    writer.Write(emp.isAlive);
                    writer.Write(emp.Name);
                }
            }
        }
    }
}

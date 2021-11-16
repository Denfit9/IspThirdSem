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
        IEnumerable<Employee> IFileService.ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                List<Employee> read = new();
                while (reader.PeekChar() > -1)
                {
                    int ager = reader.ReadInt32();
                    bool isAliver = reader.ReadBoolean();
                    string Namer = reader.ReadString();
                    read.Add(new Employee { age = ager, isAlive = isAliver, Name = Namer });
                }
                foreach (Employee emp in read)
                {
                    yield return emp;
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

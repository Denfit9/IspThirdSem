using System;
using System.IO;
using System.Collections.Generic;
using _053505_Karachun_Lab8.Entities;
using _053505_Karachun_Lab8.Interfaces;

namespace _053505_Karachun_Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Employee> employees = new();
            IFileService tool = new FileService();
            string path = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab8\\info.txt";
            string path2 = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab8\\info2.txt";
            employees.Add(new Employee {age = 22, isAlive = true, Name = "Alex" }) ;
            employees.Add(new Employee { age = 23, isAlive = true, Name = "Petr" });
            employees.Add(new Employee { age = 34, isAlive = true, Name = "Peter" });
            employees.Add(new Employee { age = 78, isAlive = false, Name = "Jack" });
            employees.Add(new Employee { age = 42, isAlive = true, Name = "James" });
            employees.Add(new Employee { age = 63, isAlive = false, Name = "Scott" });


            if (File.Exists(path))
            {
                File.Delete(path);
                var file = File.Create(path);
                file.Close();
            }
            else
            {

                var file = File.Create(path);
                file.Close();
            }
           
            tool.SaveData(employees, path);
            //var file = File.OpenRead(path);

            File.Move(path, path2);
            List<Employee> employees2 = new();
            employees2.AddRange((tool.ReadFile(path2)));
           
        }
    }
}

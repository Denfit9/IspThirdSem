using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using _053505_Karachun_Lab8.Entities;
using _053505_Karachun_Lab8.Interfaces;

namespace _053505_Karachun_Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new();
            IFileService tool = new FileService();
            IComparer<Employee> comp = new EmployeeComparer<Employee>();
            string path = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab8\\info.txt";
            string path2 = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab8\\info2.txt";
            employees.Add(new Employee {age = 22, isAlive = true, Name = "Alex" }) ;
            employees.Add(new Employee { age = 23, isAlive = true, Name = "Petr" });
            employees.Add(new Employee { age = 34, isAlive = true, Name = "Peter" });
            employees.Add(new Employee { age = 78, isAlive = false, Name = "Jack" });
            employees.Add(new Employee { age = 42, isAlive = true, Name = "James" });
            employees.Add(new Employee { age = 63, isAlive = false, Name = "Scott" });

            Console.WriteLine("Starting List: \n"); //Showing starting unsorted list
            foreach (Employee emp1 in employees)
            {
                Console.WriteLine("Age: " + emp1.age + "  Alive: " + emp1.isAlive + "   Name: " + emp1.Name);
            }

            if (File.Exists(path)) //Deleting file if there is one with such name already and creating it 
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
           
            tool.SaveData(employees, path); //saving our information to file

            if (File.Exists(path2))   //clearing file with a new name
            {
                File.Delete(path2);
            }
          
            File.Move(path, path2);  //renaming file

            List<Employee> employees2 = new();
            employees2.AddRange((tool.ReadFile(path2))); //adding objects to list after reading them from renamed file

            IEnumerable <Employee> employees3 = employees2.OrderBy((e => e), comp); //sorted list of employess read from file before
            tool.SaveData(employees3, path2);//saving sorted list to file
            employees2.Clear();
            employees2.AddRange(tool.ReadFile(path2));//reading sorted list from the file
            Console.WriteLine("\n\nSorted List: ");
            foreach (Employee emp2 in employees2) //Showing sorted list
            {
                Console.WriteLine("Age: " + emp2.age + "  Alive: " + emp2.isAlive + "   Name: " + emp2.Name);
            }

        }
    }
}

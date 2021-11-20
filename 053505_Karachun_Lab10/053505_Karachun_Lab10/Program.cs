using System;
using _053505_Karachun_Lab10.Interfaces;
using _053505_Karachun_Lab10.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace _053505_Karachun_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Employee> employees2 = new List<Employee>();
            //Console.WriteLine("Hello World!");
            string path = ("C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab10\\info.json");
            employees.Add(new Employee { age = 22, isAlive = true, Name = "Alex" });
            employees.Add(new Employee { age = 23, isAlive = true, Name = "Petr" });
            employees.Add(new Employee { age = 34, isAlive = true, Name = "Peter" });
            employees.Add(new Employee { age = 78, isAlive = false, Name = "Jack" });
            employees.Add(new Employee { age = 42, isAlive = true, Name = "James" });
            employees.Add(new Employee { age = 63, isAlive = false, Name = "Scott" });

            Assembly asm = Assembly.LoadFrom("C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab10\\FileService\\obj\\Debug\\net5.0\\FileService.dll");
            Type t = asm.GetType("FileService.FileService1`1", true, true).MakeGenericType(typeof(Employee)); 
            object methods = Activator.CreateInstance(t);

            MethodInfo Save = t.GetMethod("SaveData");
            MethodInfo Load = t.GetMethod("ReadFile");
            object save = Save.Invoke(methods, new object[] {employees,path } );

            object load = Load.Invoke(methods, new object[] {path });
            employees2.AddRange((IList<Employee>)load);
            foreach(Employee emp in employees2)
            {
                Console.WriteLine("Age: " + emp.age + "  Alive: " + emp.isAlive + "   Name: " + emp.Name);
            }
           
            
        }
    }
}

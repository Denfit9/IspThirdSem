using System;
using Computer;
using StreamServiceLib;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace _053505_Karachun_Lab11Task2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Func<Computer1, bool> countFunc = Computer1.CompareManufactor;
            MemoryStream memstr = new();
            StreamService strserv = new();
            Thread thread1 = new(() => strserv.WriteToStreamTask(memstr));
            Thread thread2 = new(() => strserv.CopyFromStreamTask(memstr, "info.txt"));
            thread1.Start();
            thread2.Start();
            Console.WriteLine("People with manufactor Asus: " + await strserv.GetStatisticsAsync("info.txt", countFunc));
        }
    }
}

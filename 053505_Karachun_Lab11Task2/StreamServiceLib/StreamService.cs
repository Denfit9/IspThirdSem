using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Computer;

namespace StreamServiceLib
{
    public class StreamService
    {
        private object locker = new ();
        public void WriteToStream(Stream stream)
        {
            lock (locker)
            {
                Console.WriteLine("Writing in thread has been started, thread number: " + Thread.CurrentThread.ManagedThreadId);
                Random rnd = new();
                StreamWriter sw = new(stream) { AutoFlush = true };

                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(i);
                    sw.WriteLine("Owner is" + i);
                    string manufctr = "";
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            manufctr = "Asus";
                            break;
                        case 2:
                            manufctr = "HP";
                            break;
                        case 3:
                            manufctr = "Acer";
                            break;
                        case 4:
                            manufctr = "Dell";
                            break;
                        default:
                            break;
                    }
                    
                    sw.WriteLine(manufctr);
                }
                Console.WriteLine("Writing in thread has been completed, thread number is: " + Thread.CurrentThread.ManagedThreadId);
            }
        }

        public void CopyFromStream(Stream stream, string filename)
        {
            lock (locker)
            {
                Console.WriteLine("Reading from thread has been started, thread number: " + Thread.CurrentThread.ManagedThreadId);
                stream.Seek(0, SeekOrigin.Begin);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                using var fs = File.Open(filename, FileMode.OpenOrCreate);
                stream.CopyTo(fs);
                Console.WriteLine("Reading from thread has been started, thread number: " + Thread.CurrentThread.ManagedThreadId);
            }
        }
        public int GetStatistics(string filename, Func<Computer1, bool> filter)
        {
            lock (locker)
            {
                Console.WriteLine("Counting has been started, thread number: " + Thread.CurrentThread.ManagedThreadId);
                StreamReader str = new(File.Open(filename, FileMode.Open));
                int count = 0;
                List<Computer1> computers= new();
                for (int i = 0; i < 100; i++)
                {
                    var computer = new Computer1
                    {
                        number = Convert.ToInt32(str.ReadLine()),
                        owner = str.ReadLine(),
                        manufactor = str.ReadLine()
                    };
                    computers.Add(computer);

                    if (filter(computers[i]))
                    {
                        count++;
                    }
                }
                str.Dispose();
                Console.WriteLine("Counting has been finished, thread number: " + Thread.CurrentThread.ManagedThreadId);
                return count;
            }
        }
        public Task WriteToStreamTask(Stream stream)
        {
            return Task.Run(() => WriteToStream(stream));
        }

        public Task CopyFromStreamTask(Stream stream, string filename)
        {
            return Task.Run(() => CopyFromStream(stream, filename));
        }

        public async Task<int> GetStatisticsAsync(string filename, Func<Computer1, bool> filter)
        {
            return await Task.Run(() => GetStatistics(filename, filter));
        }
    }
}

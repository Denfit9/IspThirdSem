using System;
using System.Diagnostics;
using System.Threading;
using SinusFunc;

namespace CountSinus
{
    public static class CountingSinus
    {
        public delegate void Result(double result);
        public static event Result onEnd;

        public static void CountSinus(object obj)
        {
            Console.WriteLine(Thread.CurrentThread.ThreadState);
            Stopwatch stopwatch = new();
            stopwatch.Start();
            SinusArguments sinus = (SinusArguments)obj;
            double result = 0;
            double h = (sinus.a + sinus.b) / sinus.n;

            for (int i = 0; i < sinus.n; i++)
            {
                result += Math.Sin(sinus.a + h * (i + 0.5));
            }

            result *= h;
            stopwatch.Stop();
            onEnd(result);
            Console.WriteLine("Time spent: ");
            Console.WriteLine(stopwatch.Elapsed);
        }
    }

        public static class EventHandler
        {
            public static void Message(double result)
            {
                Console.WriteLine(result);
            }
        }
    
}

using System;
using SinusFunc;
using CountSinus;
using System.Threading;

namespace _053505_Karachun_Lab11Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            CountingSinus.onEnd += CountSinus.EventHandler.Message;
            SinusArguments sinus = new SinusArguments(0,1, 100000000);
            Thread thread1 = new(new ParameterizedThreadStart(CountingSinus.CountSinus));
            Thread thread2 = new(new ParameterizedThreadStart(CountingSinus.CountSinus));
            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Lowest;
            thread1.Start(sinus);
            thread2.Start(sinus);
        }
    }
}

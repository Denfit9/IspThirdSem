using System;

namespace Computer
{
    public class Computer1
    {
        public int number;
        public string owner;
        public string manufactor;
        public static string GetManufactor(string manuf) => manuf;
        
        
        public static bool CompareManufactor(Computer1 comp)
        {
            string manuf = "Asus";
            if (comp.manufactor == manuf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Computer1() { }
        public Computer1(int number, string owner, string manufactor)
        {
            this.number = number;
            this.owner = owner;
            this.manufactor = manufactor;
        }
    }
}

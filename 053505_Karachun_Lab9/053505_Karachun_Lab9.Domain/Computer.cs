using System;
using System.Collections;
using System.Collections.Generic;

namespace _053505_Karachun_Lab9.Domain
{
    [Serializable]
    public class Computer
    {
        public string manufactor { get; set; }
        public HDD hdd { get; set; }
        public Computer(string manufactor, int size)
        {
            this.manufactor = manufactor;
            this.hdd = new HDD(size);
        }
        public Computer() { }
    }
    [Serializable]
    public class HDD
    {
        public int size { get; set; }
    
        public HDD (int size)
        {           
            this.size = size;
        }
        public HDD () { }
    }
}

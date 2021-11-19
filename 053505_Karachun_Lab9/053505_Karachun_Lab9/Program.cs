using System;
using _053505_Karachun_Lab9.Domain;
using Serializer;
using System.Collections.Generic;



namespace _053505_Karachun_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab9\\SerByLinq.xml";
            string path2 = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab9\\SerByXML.xml";
            string path3 = "C:\\Users\\d0306\\Documents\\C#ThirdSemLabs\\053505_Karachun_Lab9\\SerByJSON.json";
            Console.WriteLine("Starting Collection: ");
            ISerializer serializers = new Serializer1();
            List <Computer> computers= new();
            List<Computer> computers2 = new();
            List<Computer> computers3 = new();
            List<Computer> computers4 = new();
            computers.Add(new Computer ("HP", 20 ) );
            computers.Add(new Computer("ASUS", 120));
            computers.Add(new Computer("Acer", 220));
            computers.Add(new Computer("IBM", 2020));
            computers.Add(new Computer("Dell", 20));

            //starting collection
            foreach (Computer comp in computers)
            {
                Console.WriteLine("Computer manufactor:  " + comp.manufactor + "  HDD size is :  " + comp.hdd.size);
            }

            //LINQ-TO-XML
            serializers.SerializeByLINQ(computers, path1);
            computers2.AddRange(serializers.DeSerializeByLINQ(path1));
            Console.WriteLine("\nCollection using LINQ to XML: \n ");
            foreach(Computer comp2 in computers2)
            {
                Console.WriteLine("Computer manufactor:  " + comp2.manufactor + "  HDD size is :  " + comp2.hdd.size);
            }

            //XML
            serializers.SerializeXML(computers, path2);
            computers3.AddRange(serializers.DeSerializeXML(path2));
            Console.WriteLine("\nCollection using  XML: \n ");
            foreach (Computer comp3 in computers3)
            {
                Console.WriteLine("Computer manufactor:  " + comp3.manufactor + "  HDD size is :  " + comp3.hdd.size);
            }

            //JSON
            serializers.SerializeJSON(computers, path3);
            computers4.AddRange(serializers.DeSerializeJSON(path3));
            Console.WriteLine("\nCollection using  JSON: \n ");
            foreach (Computer comp4 in computers4)
            {
                Console.WriteLine("Computer manufactor:  " + comp4.manufactor + "  HDD size is :  " + comp4.hdd.size);
            }
        }
    }
}

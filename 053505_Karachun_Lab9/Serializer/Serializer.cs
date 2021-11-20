using _053505_Karachun_Lab9.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serializer
{
    public class Serializer1 : ISerializer
    {
        public IEnumerable<Computer> DeSerializeByLINQ(string fileName)
        {
            List<Computer> computers = new();
            XDocument xdoc = XDocument.Load(fileName);
            foreach (XElement computerElement in xdoc.Element("computers").Elements("computer"))
            {
                XAttribute manufactor = computerElement.Attribute("manufactor");
                XElement size = computerElement.Element("size");
                if (manufactor != null && size != null)
                {
                    computers.Add(new Computer(manufactor.Value, Convert.ToInt32(size.Value)));
                }
            }
            return computers;

        }

        public IEnumerable<Computer> DeSerializeJSON(string fileName)
        {
            List<Computer> computers = new();
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(computers.GetType());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                computers.AddRange((List<Computer>)formatter.ReadObject(fs));
            }
            return computers;
        }

        public IEnumerable<Computer> DeSerializeXML(string fileName)
        {
            List<Computer> computers = new();
            Type type = computers.GetType();
            XmlSerializer formatter = new XmlSerializer(type);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                computers.AddRange((List<Computer>)formatter.Deserialize(fs));

            }
            return computers;
        }

        public void SerializeByLINQ(IEnumerable<Computer> comps, string fileName)
        {
            XDocument xdoc = new XDocument();
            XElement xcomps = new XElement("computers");
            foreach (Computer cmp in comps)
            {
                XElement computer = new XElement("computer");
                XAttribute manufactor = new("manufactor", cmp.manufactor);
                XElement size = new XElement("size", cmp.hdd.size);
                computer.Add(manufactor);
                computer.Add(size);

                xcomps.Add(computer);
            }
            xdoc.Add(xcomps);
            xdoc.Save(fileName);
        }

        public void SerializeJSON(IEnumerable<Computer> comps, string fileName)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(comps.GetType());
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, comps);
            }
        }

        public void SerializeXML(IEnumerable<Computer> comps, string fileName)
        {
            Type type = comps.GetType();
            XmlSerializer xml = new XmlSerializer(type);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, comps);
            }
        }
    }
}

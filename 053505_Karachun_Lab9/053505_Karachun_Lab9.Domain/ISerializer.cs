using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Karachun_Lab9.Domain
{
    public interface ISerializer
    {
        IEnumerable<Computer> DeSerializeByLINQ(string fileName);
        IEnumerable<Computer> DeSerializeXML(string fileName);
        IEnumerable<Computer> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Computer> comp, string fileName);
        void SerializeXML(IEnumerable<Computer> comp, string fileName);
        void SerializeJSON(IEnumerable<Computer> comp, string fileName);
    }
}

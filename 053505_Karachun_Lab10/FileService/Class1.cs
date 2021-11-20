using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using _053505_Karachun_Lab10.Interfaces;

namespace FileService
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(data.GetType());
        }
    }
}

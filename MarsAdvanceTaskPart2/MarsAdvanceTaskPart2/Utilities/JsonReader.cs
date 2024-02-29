using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Utilities
{
    public class JsonReader
    {

        public static List<T> LoadData<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var jsonContent = reader.ReadToEnd();
            List<T> objectList = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            return objectList;
        }



    }
}

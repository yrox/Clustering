using System.Collections.Generic;
using Newtonsoft.Json;

namespace Clustering.Json
{
    public class TableDeserializer
    {
        public Table DeserializeTable(string data)
        {
            return JsonConvert.DeserializeObject<Table>(data);
        }

        public IEnumerable<Table> DeserializeTables(string data)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Table>>(data);
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Clustering.Json
{
    public class TableSerializer
    {
        public string Serialize(Table table)
        {
            return JsonConvert.SerializeObject(table);
        }

        public string Serialize(IEnumerable<Table> tables)
        {
            return JsonConvert.SerializeObject(tables);
        }
    }
}

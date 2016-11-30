using System;
using System.Collections.Generic;
using System.Linq;

namespace Clustering
{
    public class Table 
    {
        public Table(IList<IList<string>> table)
        {
            Colunms = table.First();
            table.Remove(Colunms);
            this.table = table;
        }

        public IList<string> Colunms { get; } 

        public IList<IList<string>> table { get; }

        public IList<string> GetRowByIndex(int index)
        {
            return table[index];
        }

        public IDictionary<int, string> GetColumnByName(string name)
        {
            var result = new Dictionary<int, string>();
            var index = Colunms.IndexOf(name);
            for (var i = 0; i < table.Count; i++)
            {
                var str = table.ElementAt(i).ElementAt(index);

                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    continue;

                result.Add(i, str);
            }
            return result;
        }

        public bool AreElementsEqual(string columnName)
        {
            return GetColumnByName(columnName).Any(x => x.Key != GetColumnByName(columnName).Keys.First());
        }
    }
}

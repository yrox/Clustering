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

        public IList<IList<string>> table { get; set; }

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

                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    result.Add(i, str);
            }
            return result;
        }

        public void CorrectColumn(string columnName, IDictionary<string, IList<int>> clusers)
        {
            var columnIndex = Colunms.IndexOf(columnName);
            foreach (var cluster in clusers)
            {
                foreach (var row in cluster.Value)
                {
                    table[row][columnIndex] = table.ElementAt(cluster.Value.First()).ElementAt(columnIndex);
                }
            }
        }

        public bool AreElementsIdentical(string columnName)
        {
            var column = GetColumnByName(columnName).Values;
            return !(column.Any(x => x != column.First()));
        }
    }
}

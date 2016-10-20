using System.Collections.Generic;
using System.Linq;

namespace Clustering
{
    class Clustering
    {
        public Clustering(Table table)
        {
            initialTable = table;
        }
        public IClusteringAlg Algorythm { get; set; }
        private Table initialTable { get; }

        public IList<Table> ClusterWith(IClusteringAlg alg, string columnName)
        {
            Algorythm = alg;
            IList<string> column = initialTable.GetColumnByName(columnName).Select(Algorythm.GetKey).ToList();
            IDictionary<string, IList<int>> lineDictionary = new Dictionary<string, IList<int>>();
            for (var i = 0; i < column.Count; i++)
            {
                string line = column.ElementAt(i);
                if (lineDictionary.ContainsKey(line))
                {
                    lineDictionary[line].Add(i);
                    continue;
                }
                lineDictionary.Add(line, new List<int> { i });
            }
            return DictToTableList(lineDictionary);
        }

        private IList<Table> DictToTableList(IDictionary<string, IList<int>> dict)
        {
            IList<Table> result = new List<Table>();
            foreach (var item in dict)
            {
                var temp = new List<IList<string>>();
                temp.Add(initialTable.Colunms);
                temp.AddRange(item.Value.Select(rowNumber => initialTable.GetRowByIndex(rowNumber)).ToList());
                result.Add(new Table(temp));
            }
            return result;
        }
    }
}

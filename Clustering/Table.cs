using System.Collections.Generic;
using System.Linq;

namespace Clustering
{
    public class Table 
    {
        public Table(IList<IList<string>> rows)
        {
            Colunms = rows.First();
            rows.Remove(Colunms);
            this.Rows = rows;
        }

        public IList<string> Colunms { get; } 

        public IList<IList<string>> Rows { get; set; }

        public IList<string> GetRowByIndex(int index)
        {
            return Rows[index];
        }

        public IDictionary<int, string> GetColumnByName(string name)
        {
            var result = new Dictionary<int, string>();
            var index = Colunms.IndexOf(name);
            for (var i = 0; i < Rows.Count; i++)
            {
                var str = Rows.ElementAt(i).ElementAt(index);

                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                    result.Add(i, str);
            }
            return result;
        }

        public bool AreElementsIdentical(string columnName)
        {
            var column = GetColumnByName(columnName).Values;
            return !(column.Any(x => x != column.First()));
        }
    }
}

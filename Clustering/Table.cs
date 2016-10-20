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

        public IList<string> GetColumnByName(string name)
        {
            int index = Colunms.IndexOf(name);
            return table.Select(str => str[index]).ToList();
        }

    }
}

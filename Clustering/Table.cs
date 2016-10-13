using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    class Table
    {
        public Table(List<List<string>> table)
        {
            this.table = table;
        }

        private List<List<string>> table;

        public List<string> GetRowByIndex(int index)
        {
            return table[index];
        }

        public List<string> GetColumnByName(string name)
        {
            List<string> column = new List<string>();
            int index = table[0].IndexOf(name);
            foreach (var str in table)
            {
                column.Add(str[index]);
            }
            return column;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader rdr = new Reader();
            Table tbl = new Table(rdr.Read("input.csv"));
            var row = tbl.GetRowByIndex(0);
            var column = tbl.GetColumnByName("Value");
        }


    }
}

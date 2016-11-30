using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Clustering.IO
{
    public class TableWriter
    {
        public void Write(IList<Table> tables, string columnName)
        {
            for (var i = 0; i < tables.Count; i++)
            {
                var pathString = new StringBuilder();
                pathString.Append(Directory.GetCurrentDirectory());
                pathString.Append(@"\output\cluster");
                if (!tables[i].AreElementsEqual(columnName))
                {
                    pathString.Append("#");
                }
                pathString.Append(i + 1);
                pathString.Append(".csv");
                using (var sw = new StreamWriter(pathString.ToString()))
                {
                    var writer = new CsvWriter(sw);
                    foreach (var row in tables.ElementAt(i).table)
                    {
                        foreach (var cell in row)
                        {
                            writer.WriteField(cell);
                        }
                        writer.NextRecord();
                    }

                }
            }
            
        }
    }
}

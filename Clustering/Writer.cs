using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    class Writer
    {
        public void Write(List<List<string>> table)
        {
            string pathString = Directory.GetCurrentDirectory() + Guid.NewGuid() + ".csv";
            File.Create(pathString);
            using (var sw = new StreamWriter(pathString))
            {
                var writer = new CsvWriter(sw);
                writer.WriteRecords(table);

            }
        }
    }
}

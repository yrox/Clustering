using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using CsvHelper;

namespace Clustering.IO
{
    public class TableReader
    {
        public IList<IList<string>> Read(string filename)
        {
            var result = new List<IList<string>>();
            using (var sr = new StreamReader(filename))
            {
                var parser = new CsvParser(sr);
                
                while (!sr.EndOfStream)
                {
                    result.Add(parser.Read().ToList<string>());
                }
            }
            return result;        
        }
        
    }
}

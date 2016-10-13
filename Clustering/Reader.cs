using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    class Reader
    {
        public List<List<string>> Read(string filename)
        {
            List<List<string>> result = new List<List<string>>();
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

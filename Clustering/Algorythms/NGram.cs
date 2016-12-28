using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clustering.Interfaces;

namespace Clustering.Algorythms
{
    public class NGram : IClusteringAlg
    {
        public NGram(int threshold)
        {
            _nGramSize = threshold;
        }
        private int _nGramSize; 
        private string GetNGrams(string str)
        {
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i <= str.Length - _nGramSize; i++)
            {
                //result.Append(string.Concat(str.Substring(i, nGramSize).OrderBy(x => x)));
                result.Append((str.Substring(i, _nGramSize)));
            }
            return result.ToString();
        }

        public IEnumerable<string> NormalizeStrings(IEnumerable<string> stringCol)
        {
            stringCol = stringCol.ToList();
            var sm = new StringModifier();
            return stringCol.Select(x => x.ToLower()).
                Select(x => sm.RemovePunctuation(x)).
                Select(GetNGrams).
                Select(x => sm.AlphabetizeWords(x, "")).ToList();
        }

        public bool AreEqual(string str1, string str2)
        {
            return str1 == str2;
        }
    }
}
